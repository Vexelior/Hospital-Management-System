using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetProvidersByTypeAsync(string type);
    }
}
