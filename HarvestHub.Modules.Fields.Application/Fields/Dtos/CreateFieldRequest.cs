using HarvestHub.Modules.Fields.Application.Dtos;

namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record CreateFieldRequest(string Name, PointDto Center, double Area, string Color, IEnumerable<CreateVertexDto> Vertices);
}
