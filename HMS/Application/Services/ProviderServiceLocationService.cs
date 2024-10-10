using Application.DTOs;
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

        public async Task<IEnumerable<ProviderServiceLocationDto>> GetAllProviderServiceLocationsAsync()
        {
            var prSvcLoc =  await _providerServiceLocationRepository.GetProviderServiceLocationsAsync();
            var prSvcLocDto = new List<ProviderServiceLocationDto>();

            foreach (var property in prSvcLoc.GetType().GetProperties())
            {
                var prSvcLocDtoProperty = new ProviderServiceLocationDto();
                foreach (var propertyDto in prSvcLocDtoProperty.GetType().GetProperties())
                {
                    if (property.Name == propertyDto.Name)
                    {
                        propertyDto.SetValue(prSvcLocDtoProperty, property.GetValue(prSvcLoc));
                    }
                }
                prSvcLocDto.Add(prSvcLocDtoProperty);
            }
            
            return prSvcLocDto;
        }

        public async Task<ProviderServiceLocationDto> GetProviderServiceLocationByIdAsync(Guid id)
        {
            var prSvcLoc = await _providerServiceLocationRepository.GetProviderServiceLocationByIdAsync(id);
            var prSvcLocDto = new ProviderServiceLocationDto();

            foreach (var property in prSvcLoc.GetType().GetProperties())
            {
                foreach (var propertyDto in prSvcLocDto.GetType().GetProperties())
                {
                    if (property.Name == propertyDto.Name)
                    {
                        propertyDto.SetValue(prSvcLocDto, property.GetValue(prSvcLoc));
                    }
                }
            }

            return prSvcLocDto;
        }

        public async Task CreateProviderServiceLocationAsync(ProviderServiceLocationDto providerServiceLocation)
        {
            var prSvcLoc = new ProviderServiceLocation();

            foreach (var property in providerServiceLocation.GetType().GetProperties())
            {
                foreach (var propertyPrSvcLoc in prSvcLoc.GetType().GetProperties())
                {
                    if (property.Name == propertyPrSvcLoc.Name)
                    {
                        propertyPrSvcLoc.SetValue(prSvcLoc, property.GetValue(providerServiceLocation));
                    }
                }
            }

            await _providerServiceLocationRepository.CreateProviderServiceLocationAsync(prSvcLoc);
        }

        public async Task UpdateProviderServiceLocationAsync(ProviderServiceLocationDto providerServiceLocation)
        {
            var prSvcLoc = new ProviderServiceLocation();

            foreach (var property in providerServiceLocation.GetType().GetProperties())
            {
                foreach (var propertyPrSvcLoc in prSvcLoc.GetType().GetProperties())
                {
                    if (property.Name == propertyPrSvcLoc.Name)
                    {
                        propertyPrSvcLoc.SetValue(prSvcLoc, property.GetValue(providerServiceLocation));
                    }
                }
            }

            await _providerServiceLocationRepository.UpdateProviderServiceLocationAsync(prSvcLoc);
        }

        public async Task DeleteProviderServiceLocationAsync(Guid id)
        {
            var prSvcLoc = await _providerServiceLocationRepository.GetProviderServiceLocationByIdAsync(id);
            if (prSvcLoc != null) await _providerServiceLocationRepository.DeleteProviderServiceLocationAsync(id);
        }
    }
}
