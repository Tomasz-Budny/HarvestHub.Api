using HarvestHub.Modules.Fields.Application.Dtos;

namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record UpdateVerticesRequest(IEnumerable<UpdateVertexDto> Vertices, double Area, PointDto Center);
}
