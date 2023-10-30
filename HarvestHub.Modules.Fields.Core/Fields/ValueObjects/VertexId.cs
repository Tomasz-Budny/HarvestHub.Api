namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record VertexId
    {
        public Guid Value { get; }

        public VertexId(Guid value)
        {
            Value = value;
        }

        public static implicit operator VertexId(string value) => new(value);

        public static implicit operator Guid(VertexId vertexId) => vertexId.Value;
    }
}
