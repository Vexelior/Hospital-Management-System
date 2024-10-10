using Application.Interfaces;
using Core.Entities.Provider;
using Core.Interfaces;

namespace Application.Services
{
    public class ProviderServiceLocationService : IProviderServiceLocationService
    {
        private readonly IProviderServiceLocationRepository _providerServiceLocationRepository;

        public ProviderServiceLocationService(IProviderServiceLocationRepository providerServiceLocationRepository)
        {
            _providerServiceLocationRepository = providerServiceLocationRepository;
        }

        public async Task<IEnumerable<ProviderServiceLocation>> GetAllProviderServiceLocationsAsync()
        {
            return await _providerServiceLocationRepository.GetProviderServiceLocationsAsync();
        }

        public async Task<ProviderServiceLocation> GetProviderServiceLocationByIdAsync(Guid id)
        {
            return await _providerServiceLocationRepository.GetProviderServiceLocationByIdAsync(id);
        }
    }
}
