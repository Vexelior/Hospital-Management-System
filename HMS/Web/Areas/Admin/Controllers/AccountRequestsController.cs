using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AccountRequestsController : Controller
    {
        private readonly AccountRequestService _service;

        public AccountRequestsController(AccountRequestService service)
        {
            _service = service;
        }

        [Route("admin/account-requests")]
        public async Task<IActionResult> Index()
        {
            var requests = await _service.GetAllRequestsAsync();
            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(Guid id)
        {
            var adminUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(adminUserId))
            {
                throw new Exception("Account ID not found.");
            }

            await _service.ApproveRequestAsync(id, adminUserId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(Guid id, string rejectionReason)
        {
            var adminUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(adminUserId))
            {
                throw new Exception("Account ID not found.");
            }

            await _service.RejectRequestAsync(id, adminUserId, rejectionReason);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadLicense(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);

            if (request.MedicalLicense == null)
            {
                return NotFound();
            }

            return File(request.MedicalLicense, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_License.pdf");
        }

        public async Task<IActionResult> DownloadCertification(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);

            if (request.Certification == null)
            {
                return NotFound();
            }

            return File(request.Certification, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_Certification.pdf");
        }

        public async Task<IActionResult> DownloadCV(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);

            if (request.Resume == null)
            {
                return NotFound();
            }

            return File(request.Resume, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_Resume.pdf");
        }
    }
}
