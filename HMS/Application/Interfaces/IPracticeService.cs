using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Core.Entities;

namespace Application.Interfaces
{
    public interface IPracticeService
    {
        Task<PracticeDto> GetPracticeByIdAsync(int id);
        Task<IEnumerable<PracticeDto>> GetAllPracticesAsync();
        Task AddPracticeAsync(PracticeDto practice);
        Task UpdatePracticeAsync(PracticeDto practice);
        Task DeletePracticeAsync(int id);
    }
}
