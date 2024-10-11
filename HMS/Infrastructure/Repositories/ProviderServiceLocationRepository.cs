using Core.Entities.Provider;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProviderServiceLocationRepository : RepositoryBase<ProviderServiceLocation>, IProviderServiceLocationRepository
    {
        public ProviderServiceLocationRepository(HospitalContext context) : base(context) { }

    }
}
