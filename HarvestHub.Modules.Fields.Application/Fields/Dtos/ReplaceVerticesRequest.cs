namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record ReplaceVerticesRequest(IEnumerable<ReplaceVertexDto> Vertices, double Area);
}
