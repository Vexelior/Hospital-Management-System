using Core.Entities.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProviderServiceLocationRepository
    {
        Task<ProviderServiceLocation> GetProviderServiceLocationByIdAsync(Guid id);
        Task<IReadOnlyList<ProviderServiceLocation>> GetProviderServiceLocationsAsync();
    }
}
