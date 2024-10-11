using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Claims;
using Core.Interfaces;

namespace Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public async Task<ClaimDto> GetClaimByIdAsync(Guid id)
        {
            var claim = await _claimRepository.GetByIdAsync(id);
            var claimDto = new ClaimDto();

            foreach (var property in claim.GetType().GetProperties())
            {
                var claimDtoProperty = claimDto.GetType().GetProperty(property.Name);
                if (claimDtoProperty != null) claimDtoProperty.SetValue(claimDto, property.GetValue(claim));
            }

            return claimDto;
        }

        public async Task<IEnumerable<ClaimDto>> GetAllClaimsAsync()
        {
            var claims = await _claimRepository.ListAllAsync();
            var claimDtos = new List<ClaimDto>();

            foreach (var claim in claims)
            {
                var claimDto = new ClaimDto();
                foreach (var property in claim.GetType().GetProperties())
                {
                    var claimDtoProperty = claimDto.GetType().GetProperty(property.Name);
                    if (claimDtoProperty != null) claimDtoProperty.SetValue(claimDto, property.GetValue(claim));
                }
                claimDtos.Add(claimDto);
            }

            return claimDtos;
        }

        public async Task<IEnumerable<ClaimDto>> GetClaimsByPatientIdAsync(Guid id)
        {
            var claims = await _claimRepository.GetClaimsByPatientIdAsync(id);
            var claimDtos = new List<ClaimDto>();

            foreach (var claim in claims)
            {
                var claimDto = new ClaimDto();
                foreach (var property in claim.GetType().GetProperties())
                {
                    var claimDtoProperty = claimDto.GetType().GetProperty(property.Name);
                    if (claimDtoProperty != null) claimDtoProperty.SetValue(claimDto, property.GetValue(claim));
                }
                claimDtos.Add(claimDto);
            }

            return claimDtos;
        }

        public async Task AddClaimAsync(ClaimDto claimDto)
        {
            var claim = new Claim();

            foreach (var property in claimDto.GetType().GetProperties())
            {
                var claimProperty = claim.GetType().GetProperty(property.Name);
                if (claimProperty != null) claimProperty.SetValue(claim, property.GetValue(claimDto));
            }

            await _claimRepository.AddAsync(claim);
        }

        public async Task UpdateClaimAsync(ClaimDto claimDto)
        {
            var claim = await _claimRepository.GetByIdAsync(claimDto.Id);

            foreach (var property in claimDto.GetType().GetProperties())
            {
                var claimProperty = claim.GetType().GetProperty(property.Name);
                if (property.GetValue(claimDto) != null && claimProperty != null && 
                    property.GetValue(claimDto) != claimProperty.GetValue(claim))
                {
                    claimProperty.SetValue(claim, property.GetValue(claimDto));
                }
            }

            await _claimRepository.UpdateAsync(claim);
        }

        public async Task DeleteClaimAsync(Guid id)
        {
            var claim = await _claimRepository.GetByIdAsync(id);

            if (claim != null)
            {
                await _claimRepository.DeleteAsync(claim);
            }
        }
    }
}
