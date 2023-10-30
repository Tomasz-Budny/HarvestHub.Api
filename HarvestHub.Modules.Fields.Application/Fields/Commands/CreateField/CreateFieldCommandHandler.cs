using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
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
            var center = new Point(
                new Latitude(request.Center.Lat), 
                new Longitude(request.Center.Lng));
            var address = new Address("Poland", "Mazowieckie", "", "Żebry Kordy");
            var vertices = request.Vertices.Select((dto, i) => VertexMapper.Map(dto, i));

            var field = new Field(
                request.Id,
                request.OwnerId,
                request.Name,
                center,
                DateTime.Now,
                request.Area,
                FieldClassStatus.Unkown,
                OwnershipStatus.Unknown,
                address,
                request.Color);

            field.SetVertices(vertices);

            await _fieldRepository.AddAsync(field);
        }
    }
}
