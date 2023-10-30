using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using System.Text.RegularExpressions;

namespace HarvestHub.Modules.Fields.Core.Fields.ValueObjects
{
    public record HexColor
    {
        private static readonly Regex Regex = new(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        public string Value { get; }

        public HexColor(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value))
            {
                throw new InvalidHexColorException(value);
            }

            Value = value;
        }
    }
}
