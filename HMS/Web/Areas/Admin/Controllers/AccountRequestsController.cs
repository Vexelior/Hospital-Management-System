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
            await _service.ApproveRequestAsync(id, adminUserId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(Guid id, string rejectionReason)
        {
            var adminUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.RejectRequestAsync(id, adminUserId, rejectionReason);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadLicense(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            return File(request.MedicalLicenseDocumentPath, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_MedicalLicense.pdf");
        }

        public async Task<IActionResult> DownloadCertification(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            return File(request.CertificationDocumentPath, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_Certification.pdf");
        }

        public async Task<IActionResult> DownloadCV(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            return File(request.CVDocumentPath, "application/pdf", $"{request.Id}_{request.LastName}-{request.FirstName}_CV.pdf");
        }
    }
}
