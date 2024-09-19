using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPracticeRepository : IRepository<Practice>
    {
        Task<Practice> GetPracticeByIdAsync(int id);
        Task<IEnumerable<Practice>> GetAllPracticesAsync();
        Task AddPracticeAsync(Practice patient);
        Task UpdatePracticeAsync(Practice patient);
        Task DeletePracticeAsync(int id);
    }
}
