using Core.Entities.Patient;
using Core.Entities.Provider;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Provider>> GetProvidersByTypeAsync(char type)
        {
            return await _context.Providers.Where(p => p.TypeIndicator == type).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsByProviderAsync(Guid id)
        {
            return await _context.Patients.Where(p => p.ProviderId == id).ToListAsync();
        }
    }
}
