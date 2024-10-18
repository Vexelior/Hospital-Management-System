using Application.Services;
using Core.Entities.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;
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
            var viewModel = new AccountRequestViewModel
            {
                ListOfStates = GeolocationHelper.ListOfStates()
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountRequestViewModel model)
        {
            var potentialExistingRequest = await _service.CheckExistingAccountRequest(model.Email, model.MedicalLicenseNumber);

            if (potentialExistingRequest)
            {
                ModelState.AddModelError(string.Empty, "An account request with this email or medical license number already exists.");
                return View(model);
            }

            var listOfStates = GeolocationHelper.ListOfStates();
            
            if (listOfStates != null)
            {
                model.ListOfStates = listOfStates;
            }

            if (model.YearsOfExperience == 0)
            {
                ModelState.AddModelError("YearsOfExperience", "Years of experience must be greater than 0.");
                return View(model);
            }
            
            if (model.DateOfBirth == DateTime.MinValue || model.DateOfBirth > DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Please enter a valid date of birth.");
                return View(model);
            }

            var foundMatchingState = false;
            foreach (var state in listOfStates)
            {
                if (state.Value == model.SelectedState)
                {
                    foundMatchingState = true;
                    break;
                }
            }

            if (!foundMatchingState)
            {
                ModelState.AddModelError("SelectedState", "Please select a valid state.");
                return View(model);
            }

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
                    State = model.SelectedState,
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
