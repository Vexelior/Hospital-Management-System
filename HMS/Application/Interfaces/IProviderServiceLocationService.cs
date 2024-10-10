using Core.Entities.Provider;

namespace Application.Interfaces
{
    public interface IProviderServiceLocationService
    {
        Task<IEnumerable<ProviderServiceLocation>> GetAllProviderServiceLocationsAsync();
        Task<ProviderServiceLocation> GetProviderServiceLocationByIdAsync(Guid id);
    }
}
