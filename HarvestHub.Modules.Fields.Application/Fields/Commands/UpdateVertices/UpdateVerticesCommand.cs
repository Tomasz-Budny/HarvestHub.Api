using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.UpdateVertices
{
    public record UpdateVerticesCommand(
        Guid FieldId, 
        Guid OwnerId, 
        IEnumerable<UpdateVertexDto> Vertices,
        double Area, 
        PointDto Center
    ) : ICommand;
}
