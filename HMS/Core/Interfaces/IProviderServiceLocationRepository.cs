using Core.Entities.Provider;

namespace Core.Interfaces
{
    public interface IProviderServiceLocationRepository
    {
        Task<ProviderServiceLocation> GetProviderServiceLocationByIdAsync(Guid id);
        Task<IEnumerable<ProviderServiceLocation>> GetProviderServiceLocationsAsync();
        Task CreateProviderServiceLocationAsync(ProviderServiceLocation providerServiceLocation);
        Task UpdateProviderServiceLocationAsync(ProviderServiceLocation providerServiceLocation);
        Task DeleteProviderServiceLocationAsync(Guid id);
    }
}
