using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
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

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor =  await _doctorRepository.GetById(id);
            return new DoctorDto { Id = doctor.Id, Name = doctor.Name, Practices = doctor.Practices, Specialties = doctor.Specialties };
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAll();
            return doctors.Select(d => new DoctorDto { Id = d.Id, Name = d.Name, Practices = d.Practices, Specialties = d.Specialties });
        }

        public async Task<DoctorDto> AddDoctorAsync(DoctorDto doctorDto)
        {
            var newDoctor = new Doctor { Name = doctorDto.Name, Practices = doctorDto.Practices, Specialties = doctorDto.Specialties };
            await _doctorRepository.Add(newDoctor);
            return new DoctorDto { Id = newDoctor.Id, Name = newDoctor.Name, Practices = newDoctor.Practices, Specialties = newDoctor.Specialties };
        }

        public async Task UpdateDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Id = doctorDto.Id, Name = doctorDto.Name, Specialties = doctorDto.Specialties,
                Practices = doctorDto.Practices
            };
            await _doctorRepository.Update(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetById(id);
            if (doctor != null)
            {
                await _doctorRepository.Delete(doctor.Id);
            }
        }
    }
}
