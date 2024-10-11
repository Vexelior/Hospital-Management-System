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
            var patient = await _patientRepository.GetByIdAsync(id);
            var patientDto = new PatientDto();
            
            foreach (var property in patientDto.GetType().GetProperties())
            {
                property.SetValue(patientDto, patient.GetType().GetProperty(property.Name)?.GetValue(patient));
            }

            return patientDto;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.ListAllAsync();
            var patientDtos = new List<PatientDto>();

            foreach (var patient in patients)
            {
                var patientDto = new PatientDto();
                foreach (var property in patientDto.GetType().GetProperties())
                {
                    property.SetValue(patientDto, patient.GetType().GetProperty(property.Name)?.GetValue(patient));
                }
                patientDtos.Add(patientDto);
            }

            return patientDtos;
        }

        public async Task AddPatientAsync(PatientDto patientDto)
        {
            var patient = new Patient();
            foreach (var property in patient.GetType().GetProperties())
            {
                property.SetValue(patient, patientDto.GetType().GetProperty(property.Name)?.GetValue(patientDto));
            }
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientDto patientDto)
        {
            var patient = await _patientRepository.GetByIdAsync(patientDto.Id);

            foreach (var property in patient.GetType().GetProperties())
            {
                property.SetValue(patient, patientDto.GetType().GetProperty(property.Name)?.GetValue(patientDto));
            }

            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeletePatientAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient != null)
            {
                await _patientRepository.DeleteAsync(patient);
            }
        }
    }
}
