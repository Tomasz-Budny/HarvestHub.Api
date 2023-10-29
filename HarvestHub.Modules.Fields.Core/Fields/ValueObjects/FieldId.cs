namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record FieldId
    {
        public Guid Value { get; set; }

        public FieldId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(FieldId userId) => userId.Value;
    }
}
