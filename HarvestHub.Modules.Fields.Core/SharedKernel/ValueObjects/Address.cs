namespace HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects
{
    public record Address
    {
        public string Country { get; }
        public string AdministrativeDivisionLevelOne { get; }
        public string? AdministrativeDivisionLevelTwo { get; }
        public string City { get; }

        public Address(string country, string administrativeDivisionLevelOne, string administrativeDivisionLevelTwo, string city)
        {
            Country = country;
            AdministrativeDivisionLevelOne = administrativeDivisionLevelOne;
            AdministrativeDivisionLevelTwo = administrativeDivisionLevelTwo;
            City = city;
        }
    }
}
