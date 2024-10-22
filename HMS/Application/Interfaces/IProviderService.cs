using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProviderService
    {
        public Task<IEnumerable<ProviderDto>> GetAllProvidersAsync();
        public Task<ProviderDto> GetProviderByIdAsync(Guid id);
        public Task<IEnumerable<ProviderDto>> GetProvidersByTypeAsync(char type);
        public Task<IEnumerable<PatientDto>> GetPatientsByProviderAsync(Guid id);
        public Task AddProviderAsync(ProviderDto provider);
        public Task UpdateProviderAsync(ProviderDto provider);
        public Task DeleteProviderAsync(Guid id);
    }
}
