using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Application.Services
{
    public interface IAddressService
    {
        Task<Address> GetAddressAsync(double latitude, double longitude);
    }
}
