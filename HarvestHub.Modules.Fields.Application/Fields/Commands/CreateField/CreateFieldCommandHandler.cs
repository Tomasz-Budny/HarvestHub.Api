using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Application.Services;
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
        private readonly IAddressService _addressService;

        public CreateFieldCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker, IAddressService addressService)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
            _addressService = addressService;
        }

        public async Task Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, name, point, area, color, verticesDto) = request;
            var center = PointMapper.Map(point);

            var address = await _addressService.GetAddressAsync(point.Lat, point.Lng);
                
            var vertices = verticesDto.Select((dto, i) => VertexMapper.Map(dto));

            var field = 
                new Field(fieldId, ownerId, name, center, DateTime.Now, 
                area, FieldClassStatus.Unknown, OwnershipStatus.Unknown, address, color);

            field.SetVertices(vertices);

            await _fieldRepository.AddAsync(field, cancellationToken);
            await _messageBroker.PublishAsync(new FieldCreated(fieldId, ownerId, name, area));
        }
    }
}
