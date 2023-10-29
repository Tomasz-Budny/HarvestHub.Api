namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record Vertice
    {
        public Longitude Longitude { get; }
        public Latitude Latitude { get; }

        public Vertice(Longitude longitude, Latitude latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
