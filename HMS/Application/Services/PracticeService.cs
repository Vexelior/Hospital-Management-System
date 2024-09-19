using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
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

        public async Task<IEnumerable<PracticeDto>> GetAllPracticesAsync()
        {
            var practices = await _practiceRepository.GetAllPracticesAsync();
            return practices.Select(p => new PracticeDto { Id = p.Id, Name = p.Name, Location = p.Location });
        }

        public async Task<PracticeDto> GetPracticeByIdAsync(int id)
        {
            var practice = await _practiceRepository.GetPracticeByIdAsync(id);
            return new PracticeDto { Id = practice.Id, Name = practice.Name, Location = practice.Location };
        }

        public async Task AddPracticeAsync(PracticeDto practiceDto)
        {
            var practice = new Practice() { Name = practiceDto.Name, Location = practiceDto.Location };
            await _practiceRepository.AddAsync(practice);
        }

        public async Task UpdatePracticeAsync(PracticeDto practiceDto)
        {
            var practice = await _practiceRepository.GetPracticeByIdAsync(practiceDto.Id);
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
