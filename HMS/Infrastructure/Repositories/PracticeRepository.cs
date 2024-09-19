using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PracticeRepository : RepositoryBase<Practice>, IPracticeRepository
    {
        public PracticeRepository(HospitalContext context) : base(context) { }

        public async Task<Practice> GetPracticeByIdAsync(int id)
        {
            return await _context.Practices.FindAsync(id);
        }

        public async Task<IEnumerable<Practice>> GetAllPracticesAsync()
        {
            return await _context.Practices.ToListAsync();
        }

        public async Task AddPracticeAsync(Practice practice)
        {
            await _context.Practices.AddAsync(practice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePracticeAsync(Practice practice)
        {
            var practiceToUpdate = await _context.Practices.FindAsync(practice.Id);
            if (practiceToUpdate == null)
            {
                throw new Exception("Practice not found");
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePracticeAsync(int id)
        {
            var practice = await GetPracticeByIdAsync(id);
            if (practice != null)
            {
                _context.Practices.Remove(practice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
