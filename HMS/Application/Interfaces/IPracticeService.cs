using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IPracticeService
    {
        Task<IEnumerable<Practice>> GetAllPracticesAsync();
        Task<Practice> GetPracticeByIdAsync(int id);
        Task AddPracticeAsync(Practice practice);
        Task UpdatePracticeAsync(Practice practice);
        Task DeletePracticeAsync(int id);
    }
}
