using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Application.Fields.Mappers
{
    public static class PointMapper
    {
        public static PointDto MapToDto(Point point)
        {
            return new PointDto(point.Latitude, point.Longitude);
        }
    }
}
