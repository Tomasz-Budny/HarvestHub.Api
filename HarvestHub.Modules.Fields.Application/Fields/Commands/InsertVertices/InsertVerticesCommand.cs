using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.InsertVertices
{
    public record InsertVerticesCommand(Guid FieldId, Guid OwnerId, IEnumerable<VertexDto> Vertices) : ICommand;
}
