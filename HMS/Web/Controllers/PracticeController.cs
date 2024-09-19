using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Exception = System.Exception;

namespace Web.Controllers
{
    public class PracticeController : Controller
    {
        private readonly PracticeService _practiceService;

        public PracticeController(PracticeService practiceService)
        {
            _practiceService = practiceService;
        }

        public async Task<IActionResult> Index()
        {
            var practiceDtos = await _practiceService.GetAllPracticesAsync();
            var practices = practiceDtos.Select(p => new Practice { Id = p.Id, Name = p.Name, Location = p.Location });

            return View(practices);
        }

        public async Task<IActionResult> Details(int id)
        {
            var practiceDto = await _practiceService.GetPracticeByIdAsync(id);

            if (practiceDto == null)
            {
                return NotFound();
            }

            var practice = new Practice { Id = practiceDto.Id, Name = practiceDto.Name, Location = practiceDto.Location };

            return View(practice);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                var practiceDto = new PracticeDto { Name = practice.Name, Location = practice.Location };
                await _practiceService.AddPracticeAsync(practiceDto);

                return RedirectToAction(nameof(Index));
            }
            return View(practice);
        }

        // GET: Practice/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var practiceDto = await _practiceService.GetPracticeByIdAsync(id);

            if (practiceDto == null)
            {
                return NotFound();
            }

            var practice = new Practice { Id = practiceDto.Id, Name = practiceDto.Name, Location = practiceDto.Location };

            return View(practice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Practice practice)
        {
            if (id != practice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var practiceDto = await _practiceService.GetPracticeByIdAsync(id);
                practiceDto.Name = practice.Name;
                practiceDto.Location = practice.Location;

                await _practiceService.UpdatePracticeAsync(practiceDto);

                return RedirectToAction(nameof(Index));
            }

            return View(practice);
        }

        // GET: Practice/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var practiceDto = await _practiceService.GetPracticeByIdAsync(id);

            if (practiceDto == null)
            {
                return NotFound();
            }

            var practice = new Practice { Id = practiceDto.Id, Name = practiceDto.Name, Location = practiceDto.Location };

            return View(practice);
        }

        // POST: Practice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var practice = await _practiceService.GetPracticeByIdAsync(id);
            if (practice != null)
            {
                await _practiceService.DeletePracticeAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
