using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Modules.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    internal sealed class CreateFieldCommandHandler : ICommandHandler<CreateFieldCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMessageBroker _messageBroker;

        public CreateFieldCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
        }

        public async Task Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, name, point, area, color, verticesDto) = request;
            var center = new Point(point.Lat, point.Lng);
            var address = new Address("Poland", "Mazowieckie", "", "Żebry Kordy");
            var vertices = verticesDto.Select((dto, i) => VertexMapper.Map(dto));

            var field = 
                new Field(fieldId, ownerId, name, center, DateTime.Now, 
                area, FieldClassStatus.Unknown, OwnershipStatus.Unknown, address, color);

            field.SetVertices(vertices);

            await _fieldRepository.AddAsync(field);
            await _messageBroker.PublishAsync(new FieldCreated(fieldId, ownerId, name, area));
        }
    }
}
