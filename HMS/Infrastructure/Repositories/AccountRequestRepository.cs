using Core.Entities.Account;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRequestRepository : RepositoryBase<AccountRequest>, IAccountRequestRepository
    {
        public AccountRequestRepository(HospitalContext context) : base(context) { }

        public async Task<AccountRequest> GetRequestByStatus(string status)
        {
            return await _context.AccountRequests.Where(a => nameof(a.Status).ToLower() == status.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<AccountRequest> GetRequestByName(string name)
        {
            return await _context.AccountRequests.Where(a => a.FirstName.ToLower() + a.LastName.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<AccountRequest> GetRequestByEmail(string email)
        {
            return await _context.AccountRequests.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<AccountRequest> GetRequestByMedicalLicenseNumber(string licenseNumber)
        {
            return await _context.AccountRequests.Where(a => a.MedicalLicenseNumber.ToLower() == licenseNumber.ToLower()).FirstOrDefaultAsync();
        }
    }
}
