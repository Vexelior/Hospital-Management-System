using Application.DTOs;
using Application.Interfaces;
using Core.Interfaces;
using Core.Entities.Patient;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                MiddleName = patient.MiddleName,
                Suffix = patient.Suffix,
                DateOfBirth = patient.DateOfBirth,
                DateOfDeath = patient.DateOfDeath,
                Address1 = patient.Address1,
                Address2 = patient.Address2,
                City = patient.City,
                State = patient.State,
                ZipCode = patient.ZipCode,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                MaritalStatus = patient.MaritalStatus
            };
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return patients.Select(p => new PatientDto 
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                MiddleName = p.MiddleName,
                Suffix = p.Suffix,
                DateOfBirth = p.DateOfBirth,
                DateOfDeath = p.DateOfDeath,
                Address1 = p.Address1,
                Address2 = p.Address2,
                City = p.City,
                State = p.State,
                ZipCode = p.ZipCode,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                MaritalStatus = p.MaritalStatus
            });
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var patient = new Patient 
            { 
                Id = patientDto.Id,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                MiddleName = patientDto.MiddleName,
                Suffix = patientDto.Suffix,
                DateOfBirth = patientDto.DateOfBirth,
                DateOfDeath = patientDto.DateOfDeath,
                Address1 = patientDto.Address1,
                Address2 = patientDto.Address2,
                City = patientDto.City,
                State = patientDto.State,
                ZipCode = patientDto.ZipCode,
                PhoneNumber = patientDto.PhoneNumber,
                Email = patientDto.Email,
                MaritalStatus = patientDto.MaritalStatus
            };
            await _patientRepository.AddPatientAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientDto patientDto)
        {
            var patient = new Patient 
            {
                Id = patientDto.Id,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                MiddleName = patientDto.MiddleName,
                Suffix = patientDto.Suffix,
                DateOfBirth = patientDto.DateOfBirth,
                DateOfDeath = patientDto.DateOfDeath,
                Address1 = patientDto.Address1,
                Address2 = patientDto.Address2,
                City = patientDto.City,
                State = patientDto.State,
                ZipCode = patientDto.ZipCode,
                PhoneNumber = patientDto.PhoneNumber,
                Email = patientDto.Email,
                MaritalStatus = patientDto.MaritalStatus
            };
            await _patientRepository.UpdatePatientAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
        }
    }
}
