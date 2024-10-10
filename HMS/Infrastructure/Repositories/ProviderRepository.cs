using Core.Entities.Provider;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(HospitalContext context) : base(context) { }
        public async Task<IEnumerable<Provider>> GetProvidersByTypeAsync(char type)
        {
            return await _context.Providers
                .Where(p => p.TypeIndicator == type).ToListAsync();
        }
    }
}
