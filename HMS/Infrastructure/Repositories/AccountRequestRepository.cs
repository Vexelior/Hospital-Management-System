using Core.Entities.Account;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRequestRepository : RepositoryBase<AccountRequest>, IAccountRequestRepository
    {
        public AccountRequestRepository(HospitalContext context) : base(context) { }

        public async Task<List<AccountRequest>> GetRequestByStatus(string status)
        {
            return await _context.AccountRequests.Where(a => nameof(a.Status).ToLower().Equals(status.ToLower())).ToListAsync();
        }

        public async Task<List<AccountRequest>> GetRequestByName(string name)
        {
            return await _context.AccountRequests.Where(a => a.FirstName.ToLower().Contains(name.ToLower()) || a.LastName.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<AccountRequest> GetRequestByEmail(string email)
        {
            return await _context.AccountRequests.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }
    }
}
