using Application.Services;
using Core.Entities.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountRequestsController : Controller
    {
        private readonly AccountRequestService _service;

        public AccountRequestsController(AccountRequestService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new AccountRequest
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    State = model.State,
                    City = model.City,
                    MedicalLicenseNumber = model.MedicalLicenseNumber,
                    Specialization = model.Specialization,
                    YearsOfExperience = model.YearsOfExperience,
                    MedicalLicenseDocumentPath = await SaveFile(model.MedicalLicenseDocument),
                    CertificationDocumentPath = await SaveFile(model.CertificationDocument),
                    CVDocumentPath = await SaveFile(model.CVDocument)
                };

                await _service.SubmitRequestAsync(request);
                return RedirectToAction("SubmissionSuccess");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult SubmissionSuccess()
        {
            return View();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/uploads/" + file.FileName;
        }
    }
}
