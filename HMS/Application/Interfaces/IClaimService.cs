using Application.DTOs;

namespace Application.Interfaces
{
    public interface IClaimService
    {
        Task<ClaimDto> GetClaimByIdAsync(Guid id);
        Task<IEnumerable<ClaimDto>> GetAllClaimsAsync();
        Task<IEnumerable<ClaimDto>> GetClaimsByPatientIdAsync(Guid id);
        Task AddClaimAsync(ClaimDto claimDto);
        Task UpdateClaimAsync(ClaimDto claimDto);
        Task DeleteClaimAsync(Guid id);
        Task SubmitClaimAsync(ClaimDto claim);
    }
}
