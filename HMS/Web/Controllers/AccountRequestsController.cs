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

        [Route("account-request")]
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
        [Route("account-request")]
        public async Task<IActionResult> Create(AccountRequestViewModel model)
        {
            var potentialExistingRequest = await _service.CheckExistingAccountRequest(model.Email);

            if (potentialExistingRequest)
            {
                ModelState.AddModelError("Email", "An account request with this email already exists.");
                return View(model);
            }

            var listOfStates = GeolocationHelper.ListOfStates();
            
            if (listOfStates != null)
            {
                model.ListOfStates = listOfStates;
            }
            
            if (model.DateOfBirth == DateTime.MinValue || model.DateOfBirth > DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Please enter a valid date of birth.");
                return View(model);
            }

            var foundMatchingState = false;
            if (listOfStates != null)
            {
                if (listOfStates.Any(state => state.Value == model.SelectedState))
                {
                    foundMatchingState = true;
                }
            }

            if (!foundMatchingState)
            {
                ModelState.AddModelError("SelectedState", "Please select a valid state.");
                return View(model);
            }

            if (!ModelState.IsValid) return View(model);

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
                MedicalLicense = await ConvertFormFileToByteArray(model.MedicalLicenseDocument),
                Certification = await ConvertFormFileToByteArray(model.CertificationDocument),
                Resume = await ConvertFormFileToByteArray(model.CVDocument)
            };

            await _service.SubmitRequestAsync(request);
            return RedirectToAction("SubmissionSuccess");
        }

        [AllowAnonymous]
        [Route("account-request/success")]
        public IActionResult SubmissionSuccess()
        {
            return View();
        }

        private async Task<byte[]> ConvertFormFileToByteArray(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
