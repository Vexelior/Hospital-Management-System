using Core.Entities.Claims;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClaimRepository : RepositoryBase<Claim>, IClaimRepository
    {
        public ClaimRepository(HospitalContext context) : base(context) { }

        public async Task<IEnumerable<Claim>> GetClaimsByPatientIdAsync(Guid patientId)
        {
            return await _context.Claims.Where(c => c.PatientId == patientId).ToListAsync();
        }
    }
}
