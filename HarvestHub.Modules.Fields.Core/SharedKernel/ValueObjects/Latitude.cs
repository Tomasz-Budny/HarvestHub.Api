using HarvestHub.Modules.Fields.Core.Fields.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record Latitude
    {
        public double Value { get; }

        public Latitude(double value)
        {
            if (value < -90 || value > 90)
            {
                throw new InvalidLatitudeValueException(value);
            }

            Value = value;
        }

        public static implicit operator Latitude(double value) => new(value);

        public static implicit operator double(Latitude longitude) => longitude.Value;
    }
}
