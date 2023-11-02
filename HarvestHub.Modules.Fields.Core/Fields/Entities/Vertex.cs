using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Entities
{
    public class Vertex : Entity<VertexId>
    {
        public Order Order { get; set; }
        public Latitude Latitude { get; private set; }
        public Longitude Longitude { get; private set; }

        public Vertex(VertexId Id, Order order, Latitude latitude, Longitude longitude) : base(Id)
        {
            Order = order;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void SetCoordinates(Latitude latitude, Longitude longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
