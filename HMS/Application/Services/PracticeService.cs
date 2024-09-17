using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class PracticeService : IPracticeService
    {
        private readonly IPracticeRepository _practiceRepository;

        public PracticeService(IPracticeRepository practiceRepository)
        {
            _practiceRepository = practiceRepository;
        }

        public async Task<IEnumerable<Practice>> GetAllPracticesAsync()
        {
            return await _practiceRepository.ListAllAsync();
        }

        public async Task<Practice> GetPracticeByIdAsync(int id)
        {
            return await _practiceRepository.GetByIdAsync(id);
        }

        public async Task AddPracticeAsync(Practice practice)
        {
            await _practiceRepository.AddAsync(practice);
        }

        public async Task UpdatePracticeAsync(Practice practice)
        {
            await _practiceRepository.UpdateAsync(practice);
        }

        public async Task DeletePracticeAsync(int id)
        {
            var practice = await _practiceRepository.GetByIdAsync(id);
            if (practice != null)
            {
                await _practiceRepository.DeleteAsync(practice);
            }
        }
    }
}
