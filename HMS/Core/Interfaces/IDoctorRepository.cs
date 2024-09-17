using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetById(int id);
        Task<IEnumerable<Doctor>> GetAll();
        Task Add(Doctor patient);
        Task Update(Doctor patient);
        Task Delete(int id);
    }
}
