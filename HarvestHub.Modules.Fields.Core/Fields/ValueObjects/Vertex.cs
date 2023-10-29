namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record Vertex
    {
        public Longitude Longitude { get; }
        public Latitude Latitude { get; }

        public Vertex(Longitude longitude, Latitude latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
