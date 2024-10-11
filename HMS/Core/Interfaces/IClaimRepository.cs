using Core.Entities.Claims;

namespace Core.Interfaces
{
    public interface IClaimRepository : IRepository<Claim>
    {
        Task<IEnumerable<Claim>> GetClaimsByPatientIdAsync(Guid id);
    }
}
