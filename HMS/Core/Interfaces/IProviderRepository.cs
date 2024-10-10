using Core.Entities.Provider;

namespace Core.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetAllProvidersAsync();
        Task<Provider> GetProviderByIdAsync(Guid id);
        Task<IEnumerable<Provider>> GetProvidersByTypeAsync(char type);
        Task AddProviderAsync(Provider provider);
        Task UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(Guid id);
    }
}
