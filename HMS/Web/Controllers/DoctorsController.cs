using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DoctorService _doctorService;
        private readonly SpecialtyService _specialtyService;
        private readonly PracticeService _practiceService;

        public DoctorsController(DoctorService doctorService, SpecialtyService specialtyService, PracticeService practiceService)
        {
            _doctorService = doctorService;
            _specialtyService = specialtyService;
            _practiceService = practiceService;
        }

        public async Task<IActionResult> Index()
        {
            DoctorIndexViewModel model = new()
            {
                Doctors = await _doctorService.GetDoctorsWithSpecialtiesAndPracticesAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public async Task<IActionResult> Create()
        {
            var specialties = await _specialtyService.GetAllSpecialtiesAsync();
            var practices = await _practiceService.GetAllPracticesAsync();

            DoctorCreateViewModel model = new()
            {
                Specialties = specialties,
                Practices = practices
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.AddDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            DoctorEditViewModel model = new()
            {
                Name = doctor.Name,
                Specialties = [],
                Practices = []
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
