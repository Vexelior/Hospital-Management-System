using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly SpecialtyService _specialtyService;

        public SpecialtiesController(SpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        public async Task<IActionResult> Index()
        {
            var specialties = await _specialtyService.GetAllSpecialtiesAsync();
            return View(specialties);
        }

        public async Task<IActionResult> Details(int id)
        {
            var specialty = await _specialtyService.GetSpecialtyByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                await _specialtyService.AddSpecialtyAsync(specialty);
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var specialty = await _specialtyService.GetSpecialtyByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Specialty specialty)
        {
            if (id != specialty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _specialtyService.UpdateSpecialtyAsync(specialty);
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var specialty = await _specialtyService.GetSpecialtyByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _specialtyService.DeleteSpecialtyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
