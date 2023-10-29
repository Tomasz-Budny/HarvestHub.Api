﻿namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record FieldId
    {
        public Guid Value { get; }

        public FieldId(Guid value)
        {
            Value = value;
        }

        public static implicit operator FieldId(string value) => new(value);

        public static implicit operator Guid(FieldId fieldId) => fieldId.Value;
    }
}