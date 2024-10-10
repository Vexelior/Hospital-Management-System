using Application.DTOs;
using Core.Entities.Provider;

namespace Application.Interfaces
{
    public interface IProviderServiceLocationService
    {
        Task<IEnumerable<ProviderServiceLocationDto>> GetAllProviderServiceLocationsAsync();
        Task<ProviderServiceLocationDto> GetProviderServiceLocationByIdAsync(Guid id);
        Task CreateProviderServiceLocationAsync(ProviderServiceLocationDto providerServiceLocation);
        Task UpdateProviderServiceLocationAsync(ProviderServiceLocationDto providerServiceLocation);
        Task DeleteProviderServiceLocationAsync(Guid id);
    }
}
