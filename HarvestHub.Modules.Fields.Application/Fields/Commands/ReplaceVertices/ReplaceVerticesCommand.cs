using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.ReplaceVertices
{
    public record ReplaceVerticesCommand(Guid FieldId, Guid OwnerId, IEnumerable<ReplaceVertexDto> Vertices, double Area) : ICommand;
}
