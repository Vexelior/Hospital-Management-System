using Core.Entities.Claims;

namespace Core.Interfaces
{
    public interface IClaimRepository : IRepository<Claim>
    {
        Task<Claim> GetClaimByIdAsync(Guid id);
        Task<IEnumerable<Claim>> GetAllClaimsAsync();
        Task<IEnumerable<Claim>> GetClaimsByPatientIdAsync(Guid id);
        Task AddClaimAsync(Claim claim);
        Task UpdateClaimAsync(Claim claim);
        Task DeleteClaimAsync(Guid id);
    }
}
