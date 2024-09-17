using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetDoctorByIdAsync(int id);
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> AddDoctorAsync(DoctorDto doctor);
        Task UpdateDoctorAsync(DoctorDto doctor);
        Task DeleteDoctorAsync(int id);
    }
}
