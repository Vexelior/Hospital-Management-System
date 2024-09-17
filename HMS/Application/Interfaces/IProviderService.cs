using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProviderService
    {
        public Task<IEnumerable<Provider>> GetAllProvidersAsync();
        public Task<Provider> GetProviderByIdAsync(int id);
        public Task<IEnumerable<Provider>> GetProvidersByTypeAsync(string type);
        public Task AddProviderAsync(Provider provider);
        public Task UpdateProviderAsync(Provider provider);
        public Task DeleteProviderAsync(int id);
    }
}
