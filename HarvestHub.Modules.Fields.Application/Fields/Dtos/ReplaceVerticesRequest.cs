using HarvestHub.Modules.Fields.Application.Dtos;

namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record ReplaceVerticesRequest(IEnumerable<ReplaceVertexDto> Vertices, double Area, PointDto Center);
}
