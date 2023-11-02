using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    public record CreateFieldCommand(Guid FieldId, Guid OwnerId, string Name, PointDto Center, double Area, string Color, IEnumerable<CreateVertexDto> Vertices) : ICommand;
}
