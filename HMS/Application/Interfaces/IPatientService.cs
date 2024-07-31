using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task AddPatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(PatientDto patientDto);
        Task DeletePatientAsync(int id);
    }
}
