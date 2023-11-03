using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Application.Mappers
{
    public static class PointMapper
    {
        public static PointDto MapToDto(Point point)
        {
            return new PointDto(point.Latitude, point.Longitude);
        }

        public static Point Map(PointDto point)
        {
            return new Point(point.Lat, point.Lng) ;
        }
    }
}
