using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithSpecialtiesAndPracticesAsync()
        {
            return await _context.Doctors
                                 .Include(d => d.Specialties)
                                 .ThenInclude(ds => ds.Specialty)
                                 .Include(d => d.Practices)
                                 .ThenInclude(dp => dp.Practice)
                                 .ToListAsync();
        }
    }
}
