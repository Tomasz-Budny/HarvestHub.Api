using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandHandler : ICommandHandler<CreateFieldCommand>
    {
        private readonly IFieldRepository _fieldRepository;

        public CreateFieldCommandHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            var (id, ownerId, name, point, area, color, verticesDto) = request;
            var center = new Point(point.Lat, point.Lng);
            var address = new Address("Poland", "Mazowieckie", "", "Żebry Kordy");
            var vertices = verticesDto.Select((dto, i) => VertexMapper.Map(dto, i));

            var field = 
                new Field(id, ownerId, name, center, DateTime.Now, 
                area, FieldClassStatus.Unkown, OwnershipStatus.Unknown, address, color);

            field.SetVertices(vertices);

            await _fieldRepository.AddAsync(field);
        }
    }
}
