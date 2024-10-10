using Application.Interfaces;
using Core.Entities.Provider;
using Core.Interfaces;

namespace Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<IEnumerable<Provider>> GetAllProvidersAsync()
        {
            return await _providerRepository.ListAllAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await _providerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Provider>> GetProvidersByTypeAsync(string type)
        {
            return await _providerRepository.GetProvidersByTypeAsync(type);
        }

        public async Task AddProviderAsync(Provider provider)
        {
            await _providerRepository.AddAsync(provider);
        }

        public async Task UpdateProviderAsync(Provider provider)
        {
            await _providerRepository.UpdateAsync(provider);
        }

        public async Task DeleteProviderAsync(int id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            if (provider != null)
            {
                await _providerRepository.DeleteAsync(provider);
            }
        }
    }
}
