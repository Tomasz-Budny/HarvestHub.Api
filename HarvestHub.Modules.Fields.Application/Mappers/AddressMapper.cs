using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Application.Mappers
{
    public static class AddressMapper
    {
        public static AddressDto MapToDto(Address address)
        {
            return new AddressDto(address.Country, address.AdministrativeDivisionLevelOne, address.AdministrativeDivisionLevelTwo, address.City);
        }
    }
}
