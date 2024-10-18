using Core.Entities.Account;

namespace Core.Interfaces
{
    public interface IAccountRequestRepository : IRepository<AccountRequest>
    {
        Task<List<AccountRequest>> GetRequestByStatus(string status);
        Task<List<AccountRequest>> GetRequestByName(string name);
        Task<AccountRequest> GetRequestByEmail(string email);
    }
}
