using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;

namespace HarvestHub.Modules.Fields.Application.Fields.Mappers
{
    public static class FieldMapper
    {
        public static FieldDto MapToDto(Field field)
        {
            var center = PointMapper.MapToDto(field.Center);
            var verticesDto = field.Vertices.Select(vertex => VertexMapper.MapToDto(vertex));

            return new FieldDto(field.Id, field.Name, center, field.Area, field.Color, verticesDto);
        }
    }
}
