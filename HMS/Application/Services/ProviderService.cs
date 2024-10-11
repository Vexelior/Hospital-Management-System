using Application.DTOs;
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

        public async Task<IEnumerable<ProviderDto>> GetAllProvidersAsync()
        {
            var providers =  await _providerRepository.ListAllAsync();
            var providerDtos = new List<ProviderDto>();

            foreach (var providerDto in providers)
            {
                var provider = new ProviderDto();
                foreach (var property in providerDto.GetType().GetProperties())
                {
                    provider.GetType().GetProperty(property.Name)?.SetValue(provider, property.GetValue(providerDto));
                }
                providerDtos.Add(provider);
            }

            return providerDtos;
        }

        public async Task<ProviderDto> GetProviderByIdAsync(Guid id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            var providerDto = new ProviderDto();

            foreach (var property in provider.GetType().GetProperties())
            {
                providerDto.GetType().GetProperty(property.Name)?.SetValue(providerDto, property.GetValue(provider));
            }

            return providerDto;
        }

        public async Task<IEnumerable<ProviderDto>> GetProvidersByTypeAsync(char type)
        {
            var providers = await _providerRepository.GetProvidersByTypeAsync(type);
            var providerDtos = new List<ProviderDto>();

            foreach (var providerDto in providers)
            {
                var provider = new ProviderDto();
                foreach (var property in providerDto.GetType().GetProperties())
                {
                    provider.GetType().GetProperty(property.Name)?.SetValue(provider, property.GetValue(providerDto));
                }
                providerDtos.Add(provider);
            }

            return providerDtos;
        }

        public async Task AddProviderAsync(ProviderDto provider)
        {
            var newProvider = new Provider();

            foreach (var property in provider.GetType().GetProperties())
            {
                newProvider.GetType().GetProperty(property.Name)?.SetValue(newProvider, property.GetValue(provider));
            }

            await _providerRepository.AddAsync(newProvider);
        }

        public async Task UpdateProviderAsync(ProviderDto provider)
        {
            var updatedProvider = new Provider();

            foreach (var property in provider.GetType().GetProperties())
            {
                updatedProvider.GetType().GetProperty(property.Name)?.SetValue(updatedProvider, property.GetValue(provider));
            }

            await _providerRepository.UpdateAsync(updatedProvider);
        }

        public async Task DeleteProviderAsync(Guid id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);

            if (provider != null)
            {
                await _providerRepository.DeleteAsync(provider);
            }
        }
    }
}
