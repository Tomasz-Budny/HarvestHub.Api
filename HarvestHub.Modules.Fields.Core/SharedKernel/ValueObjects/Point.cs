using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects
{
    public record Point
    {
        public Latitude Latitude { get; set; }
        public Longitude Longitude { get; set; }

        public Point(Latitude latitude, Longitude longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Point Create(string value)
        {
            var splitPointCoordinates = value.Split(',');
            return new Point(splitPointCoordinates[0], splitPointCoordinates.Last());
        }

        public override string ToString() => $"{Latitude},{Longitude}";
    }
}
