using Core.Entities.Claims;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClaimRepository : RepositoryBase<Claim>, IClaimRepository
    {
        public ClaimRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claim> GetClaimByIdAsync(Guid id)
        {
            return await _context.Claims.FindAsync(id);
        }

        public async Task<IEnumerable<Claim>> GetClaimsByPatientIdAsync(Guid patientId)
        {
            return await _context.Claims.Where(c => c.PatientId == patientId).ToListAsync();
        }

        public async Task AddClaimAsync(Claim claim)
        {
            await _context.Claims.AddAsync(claim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClaimAsync(Claim claim)
        {
            _context.Claims.Update(claim);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClaimAsync(Guid id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null) _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
        }
    }
}
