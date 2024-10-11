using Core.Entities.Account;

namespace Core.Interfaces
{
    public interface IAccountRequestRepository : IRepository<AccountRequest>
    {
        Task<AccountRequest> GetRequestByMedicalLicenseNumber(string licenseNumber);
        Task<AccountRequest> GetRequestByStatus(string status);
        Task<AccountRequest> GetRequestByName(string name);
        Task<AccountRequest> GetRequestByEmail(string email);
    }
}
