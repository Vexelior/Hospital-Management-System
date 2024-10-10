using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Patient;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalContext _context;

        public PatientRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
