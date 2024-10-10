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
    }
}
