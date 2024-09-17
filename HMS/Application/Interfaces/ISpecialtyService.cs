using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISpecialtyService
    {
        public Task<Specialty> GetSpecialtyByIdAsync(int id);
        public Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync();
        public Task<Specialty> AddSpecialtyAsync(Specialty specialty);
        public Task UpdateSpecialtyAsync(Specialty specialty);
        public Task DeleteSpecialtyAsync(int id);
    }
}
