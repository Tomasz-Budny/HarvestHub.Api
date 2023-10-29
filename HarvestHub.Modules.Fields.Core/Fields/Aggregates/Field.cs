using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Shared.Primitives;

namespace HarvestHub.Modules.Fields.Core.Fields.Aggregates
{
    public class Field : AggregateRoot<FieldId>
    {
        public Name Name { get; set; }
        public OwnerId OwnerId { get; set; }
        public Area Area { get; set; }
        public Class Class { get; set; }
        public Address Address { get; set; }
        public IReadOnlyList<Vertice> Vertices => _vertices.AsReadOnly();

        protected List<Vertice> _vertices = new List<Vertice>();

        public Field(FieldId id) : base(id)
        {
        }
    }
}
