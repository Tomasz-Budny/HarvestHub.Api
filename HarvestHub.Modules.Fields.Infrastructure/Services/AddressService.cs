using HarvestHub.Modules.Fields.Application.Dtos.Externals.GoogleGeoCode;
using HarvestHub.Modules.Fields.Application.Services;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Modules.Fields.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace HarvestHub.Modules.Fields.Infrastructure.Services
{
    internal class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleApiOptions _googleApiOptions;

        public AddressService(HttpClient httpClient, IOptions<GoogleApiOptions> googleApiOptions)
        {
            _httpClient = httpClient;
            _googleApiOptions = googleApiOptions.Value;
        }
        public async Task<Address> GetAddressAsync(double Latitude, double Longitude)
        {
            var url = $"json?latlng={Latitude.ToString().Replace(',', '.')},{Longitude.ToString().Replace(',', '.')}&key={_googleApiOptions.Key}";
            var response = await _httpClient.GetFromJsonAsync<GeoCode>(url);

            string country = response.Results[0].Address_components.Find(a => a.Types.Contains("country"))?.Long_name;
            string administrativeDivisionLevelOne = response.Results[0].Address_components.Find(a => a.Types.Contains("administrative_area_level_1"))?.Long_name;
            string administrativeDivisionLevelTwo = response.Results[0].Address_components.Find(a => a.Types.Contains("administrative_area_level_2"))?.Long_name;
            string city = response.Results[0].Address_components.Find(a => a.Types.Contains("locality"))?.Long_name;

            return new Address(country, administrativeDivisionLevelOne, administrativeDivisionLevelTwo, city);
        }
    }
}
