using Core.Entities.Provider;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProviderServiceLocationRepository : IProviderServiceLocationRepository
    {
        private readonly HospitalContext _context;

        public ProviderServiceLocationRepository(HospitalContext context)
        {
            _context = context;
        }



        public async Task<ProviderServiceLocation> GetProviderServiceLocationByIdAsync(Guid id)
        {
            return await _context.ProviderServiceLocations.FindAsync(id);
        }

        public async Task<IEnumerable<ProviderServiceLocation>> GetProviderServiceLocationsAsync()
        {
            return await _context.ProviderServiceLocations.ToListAsync();
        }

        public async Task CreateProviderServiceLocationAsync(ProviderServiceLocation providerServiceLocation)
        {
            _context.ProviderServiceLocations.Add(providerServiceLocation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProviderServiceLocationAsync(ProviderServiceLocation providerServiceLocation)
        {
            _context.Entry(providerServiceLocation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProviderServiceLocationAsync(Guid id)
        {
            var providerServiceLocation = await _context.ProviderServiceLocations.FindAsync(id);
            if (providerServiceLocation != null)
            {
                _context.ProviderServiceLocations.Remove(providerServiceLocation);
                await _context.SaveChangesAsync();
            }
        }

        public Task<ProviderServiceLocation> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProviderServiceLocation>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProviderServiceLocation> AddAsync(ProviderServiceLocation entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProviderServiceLocation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProviderServiceLocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
