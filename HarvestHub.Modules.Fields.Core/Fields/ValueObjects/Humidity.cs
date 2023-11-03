﻿using HarvestHub.Modules.Fields.Core.Fields.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record Humidity
    {
        public uint Value { get; }

        public Humidity(uint value)
        { 
            if(value > 100)
            {
                throw new InvalidHumidityValueException(value);
            }

            Value = value;
        }

        public static implicit operator Humidity(uint value) => new(value);

        public static implicit operator uint(Humidity humidity) => humidity.Value;
    }
}
