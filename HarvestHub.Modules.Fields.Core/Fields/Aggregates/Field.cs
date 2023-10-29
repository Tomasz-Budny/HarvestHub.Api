using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    public class Field : AggregateRoot<FieldId>
    {
        public OwnerId OwnerId { get; set; }
        public Name Name { get; set; }
        public Vertex Center { get; set; }
        public Area Area { get; set; }
        public Class Class { get; set; }
        public Address Address { get; set; }
        public IReadOnlyList<Vertex> Vertices => _vertices.AsReadOnly();

        protected List<Vertex> _vertices = new();

        public Field(FieldId id) : base(id)
        {
        }
    }
}
