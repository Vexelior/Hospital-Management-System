using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            return new PatientDto { PatientId = patient.Id, Name = patient.Name, Age = patient.Age };
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return patients.Select(p => new PatientDto { PatientId = p.Id, Name = p.Name, Age = p.Age });
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var patient = new Patient { Name = patientDto.Name, Age = patientDto.Age };
            await _patientRepository.AddPatientAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientDto patientDto)
        {
            var patient = new Patient { Id = patientDto.PatientId, Name = patientDto.Name, Age = patientDto.Age };
            await _patientRepository.UpdatePatientAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
        }
    }
}
