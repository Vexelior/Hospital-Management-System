using Core.Entities.Provider;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Provider>> GetAllProvidersAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(Guid id)
        {
            return await _context.Providers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Provider>> GetProvidersByTypeAsync(char type)
        {
            return await _context.Providers.Where(p => p.TypeIndicator == type).ToListAsync();
        }

        public async Task AddProviderAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProviderAsync(Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProviderAsync(Guid id)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(p => p.Id == id);
            if (provider != null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
            }
        }
    }
}
