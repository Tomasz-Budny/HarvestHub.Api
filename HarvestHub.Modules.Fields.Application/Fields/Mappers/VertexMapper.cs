using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Modules.Fields.Core.Fields.Entities;

namespace HarvestHub.Modules.Fields.Application.Fields.Mappers
{
    public static class VertexMapper
    {
        public static Vertex Map(VertexDto dto, int index)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var id = Guid.NewGuid();
            return new Vertex(id, (uint)index + 1, dto.Lat, dto.Lat);
        }

        public static VertexDto MapToDto(Vertex vertex)
        {
            return new VertexDto(vertex.Latitude, vertex.Longitude);
        }
    }
}
