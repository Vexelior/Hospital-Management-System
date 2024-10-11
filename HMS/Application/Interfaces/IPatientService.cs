using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(Guid id);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task AddPatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(PatientDto patientDto);
        Task DeletePatientAsync(Guid id);
    }
}
