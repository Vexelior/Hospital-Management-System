using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> GetDoctorByIdAsync(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        public Task<Doctor> AddDoctorAsync(Doctor doctor);
        public Task UpdateDoctorAsync(Doctor doctor);
        public Task DeleteDoctorAsync(int id);
        public Task<IEnumerable<Doctor>> GetDoctorsWithSpecialtiesAndPracticesAsync();
    }
}
