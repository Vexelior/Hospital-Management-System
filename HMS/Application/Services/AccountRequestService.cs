using System.Text;
using Application.Interfaces;
using Core.Entities.Account;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AccountRequestService
    {
        private readonly IAccountRequestRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public AccountRequestService(IAccountRequestRepository repository,
                                     UserManager<ApplicationUser> userManager,
                                     RoleManager<IdentityRole> roleManager,
                                     IEmailService emailService)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }

        public async Task<IEnumerable<AccountRequest>> GetAllRequestsAsync()
        {
            return await _repository.ListAllAsync();
        }

        private async Task<AccountRequest> GetRequestByEmailAsync(string email)
        {
            return await _repository.GetRequestByEmail(email);
        }

        private async Task<AccountRequest> GetRequestByMedicalLicenseNumberAsync(string licenseNumber)
        {
            return await _repository.GetRequestByMedicalLicenseNumber(licenseNumber);
        }

        public async Task<bool> CheckExistingAccountRequest(string email, string licenseNumber)
        {
            var existingRequestByEmail = await GetRequestByEmailAsync(email);
            var existingRequestByLicenseNumber = await GetRequestByMedicalLicenseNumberAsync(licenseNumber);

            return existingRequestByEmail != null || existingRequestByLicenseNumber != null;
        }

        public async Task SubmitRequestAsync(AccountRequest request)
        {
            request.Status = AccountRequestStatus.Pending;
            request.SubmittedAt = DateTime.UtcNow;
            await _repository.AddAsync(request);
            await _emailService.SendEmailAsync(
                "hms.medical.contact@gmail.com",
                "New Account Request Submitted",
                $"A new account request has been submitted by {request.LastName}, {request.FirstName} ({request.Email}). Please review it in the admin dashboard."
            );
        }

        public async Task ApproveRequestAsync(Guid requestId, string adminUserId)
        {
            var request = await _repository.GetByIdAsync(requestId);
            if (request == null || request.Status != AccountRequestStatus.Pending)
            {
                throw new InvalidOperationException("Invalid account request.");
            }

            var user = new ApplicationUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };

            var generatedPassword = GenerateSecurePassword();
            var result = await _userManager.CreateAsync(user, generatedPassword);

            if (result.Succeeded)
            {
                if (await _roleManager.RoleExistsAsync("Provider"))
                {
                    await _userManager.AddToRoleAsync(user, "Provider");
                }

                request.Status = AccountRequestStatus.Approved;
                request.ReviewedAt = DateTime.UtcNow;
                request.ReviewedBy = adminUserId;
                await _repository.UpdateAsync(request);

                await _emailService.SendEmailAsync(
                    user.Email,
                    "Your Account Request Has Been Approved",
                    $"Hello {user.FirstName},<br/><br/>Your account request has been approved. You can now log in to the HMS using your temporary password: <strong>{generatedPassword}</strong>.<br/><br/>Please change your password after logging in."
                );
            }
            else
            {
                throw new Exception("Failed to create user account.");
            }
        }

        public async Task RejectRequestAsync(Guid requestId, string adminUserId, string rejectionReason)
        {
            var request = await _repository.GetByIdAsync(requestId);
            if (request == null || request.Status != AccountRequestStatus.Pending)
            {
                throw new InvalidOperationException("Invalid account request.");
            }

            request.Status = AccountRequestStatus.Rejected;
            request.ReviewedAt = DateTime.UtcNow;
            request.ReviewedBy = adminUserId;
            request.RejectionReason = rejectionReason;
            await _repository.UpdateAsync(request);

            await _emailService.SendEmailAsync(
                request.Email,
                "Your Account Request Has Been Rejected",
                $"Hello {request.FirstName},<br/><br/>Your account request has been rejected for the following reason:<br/><em>{rejectionReason}</em><br/><br/>If you believe this is a mistake, please contact support."
            );
        }

        private string GenerateSecurePassword()
        {
            var random = new Random();
            var password = new StringBuilder();
            var specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            var charSets = new List<string>
            {
                "abcdefghijklmnopqrstuvwxyz",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789",
                specialChars
            };

            for (int i = 0; i < 12; i++)
            {
                var charSet = charSets[random.Next(charSets.Count)];
                password.Append(charSet[random.Next(charSet.Length)]);
            }

            return password.ToString();
        }
    }
}
