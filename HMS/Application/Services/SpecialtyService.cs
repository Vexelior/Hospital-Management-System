using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyService(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<Specialty> GetSpecialtyByIdAsync(int id)
        {
            return await _specialtyRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync()
        {
            return await _specialtyRepository.ListAllAsync();
        }

        public async Task<Specialty> AddSpecialtyAsync(Specialty specialty)
        {
            return await _specialtyRepository.AddAsync(specialty);
        }

        public async Task UpdateSpecialtyAsync(Specialty specialty)
        {
            await _specialtyRepository.UpdateAsync(specialty);
        }

        public async Task DeleteSpecialtyAsync(int id)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);
            if (specialty != null)
            {
                await _specialtyRepository.DeleteAsync(specialty);
            }
        }
    }
}
