using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Services;
using Core.Entities.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Provider.Models.ViewModels;
using Web.Helpers;

namespace Web.Areas.Provider.Controllers
{
    [Area("Provider")]
    [Authorize(Roles = "Administrator,Provider")]
    public class ClaimController : Controller
    {
        private readonly ClaimService _claimService;
        private readonly ProviderService _providerService;
        private readonly PatientService _patientService;

        public ClaimController(ClaimService claimService,
                               ProviderService providerService,
                               PatientService patientService)
        {
            _claimService = claimService;
            _providerService = providerService;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 5)
        {
            var claims = await _claimService.GetAllClaimsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                claims = await FilterClaimsBySearchString(claims, searchString);
            }

            var count = claims.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            // Order first, then paginate
            claims = claims.OrderBy(x => x.DateOfSubmission)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new ClaimIndexViewModel
            {
                Claims = claims,
                Pagination = new Pagination
                {
                    TotalPages = totalPages,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    HasPrevious = pageNumber > 1,
                    HasNext = pageNumber < totalPages
                },
                SearchString = searchString
            };

            return View(viewModel);
        }

        private async Task<List<ClaimDto>> FilterClaimsBySearchString(IEnumerable<ClaimDto> claims, string searchString)
        {
            var searchQueryClaims = new List<ClaimDto>();

            if (searchString.All(char.IsDigit))
            {
                searchQueryClaims = claims.Where(c => c.Number.Contains(searchString)).ToList();
            }
            else if (searchString.All(char.IsLetter))
            {
                var patientIds = claims.Select(c => c.PatientId).Distinct().ToList();
                foreach (var id in patientIds)
                {
                    var patient = await _patientService.GetPatientByIdAsync(id);
                    if (patient != null && (patient.FirstName.ToLower().Contains(searchString.ToLower()) || patient.LastName.ToLower().Contains(searchString.ToLower())))
                    {
                        searchQueryClaims.AddRange(claims.Where(c => c.PatientId == id));
                    }
                }
            }

            return searchQueryClaims;
        }

        public async Task<IActionResult> Create()
        {
            var providerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
            var patients = await _providerService.GetPatientsByProviderAsync(providerId);

            var patientSelectList = patients.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.LastName}, {p.FirstName}"
            });

            var claimTypes = _claimService.GetClaimTypes().Select((c, index) => new SelectListItem
            {
                Value = index.ToString(),
                Text = c
            });


            var viewModel = new SubmitClaimViewModel
            {
                ProviderId = providerId.ToString(),
                Patients = patientSelectList,
                ClaimTypes = claimTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubmitClaimViewModel viewModel)
        {
            var patients = await _providerService.GetPatientsByProviderAsync(new Guid(viewModel.ProviderId));
            var patientSelectList = patients.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.LastName}, {p.FirstName}"
            });
            viewModel.Patients = patientSelectList;
            viewModel.ClaimTypes = _claimService.GetClaimTypes().Select((c, index) => new SelectListItem
            {
                Value = index.ToString(),
                Text = c
            });

            var number = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < 13; i++)
            {
                number.Append(random.Next(0, 9));
            }

            var claimType = _claimService.GetClaimTypes().ElementAt(int.Parse(viewModel.SelectedClaimType));

            if (ModelState.IsValid)
            {
                var model = new ClaimDto()
                {
                    Number = number.ToString(),
                    Type = claimType,
                    Status = ClaimStatus.Pending,
                    FirstDateOfService = DateTime.Now,
                    LastDateOfService = DateTime.Now,
                    DateCreated = DateTime.Now,
                    DateOfSubmission = DateTime.Now,
                    DateOfResponse = DateTime.Now,
                    TotalAmount = decimal.Parse(viewModel.TotalAmountComputed),
                    AmountPaid = 0.00m,
                    PatientId = new Guid(viewModel.SelectedPatientId)
                };

                await _claimService.SubmitClaimAsync(model);
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }
    }
}
