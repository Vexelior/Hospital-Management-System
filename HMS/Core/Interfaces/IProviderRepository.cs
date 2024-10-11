using Core.Entities.Provider;

namespace Core.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetProvidersByTypeAsync(char type);
    }
}
