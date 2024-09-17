using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.ListAllAsync();
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            return await _doctorRepository.AddAsync(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor != null)
            {
                await _doctorRepository.DeleteAsync(doctor);
            }
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithSpecialtiesAndPracticesAsync()
        {
            return await _doctorRepository.GetDoctorsWithSpecialtiesAndPracticesAsync();
        }
    }
}
