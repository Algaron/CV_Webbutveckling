#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CV_Webbutveckling.Data;
using CV_Webbutveckling.Models;

namespace CV_Webbutveckling.Controllers
{
    public class EducationExperiencesController : Controller
    {
        private readonly CV_WebbutvecklingContext _context;

        public EducationExperiencesController(CV_WebbutvecklingContext context)
        {
            _context = context;
        }

        // GET: EducationExperiences
        public async Task<IActionResult> Index()
        {
            var educationExp = from w in _context.EducationExperience
                          select w;
            educationExp = educationExp.OrderByDescending(w => w.DateStart);
            return View(educationExp.AsNoTracking());
        }

        // GET: EducationExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationExperience = await _context.EducationExperience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationExperience == null)
            {
                return NotFound();
            }

            return View(educationExperience);
        }

        // GET: EducationExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateStart,DateEnd,SchoolName,EducationName,Description")] EducationExperience educationExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationExperience);
        }

        // GET: EducationExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationExperience = await _context.EducationExperience.FindAsync(id);
            if (educationExperience == null)
            {
                return NotFound();
            }
            return View(educationExperience);
        }

        // POST: EducationExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateStart,DateEnd,SchoolName,EducationName,Description")] EducationExperience educationExperience)
        {
            if (id != educationExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExperienceExists(educationExperience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(educationExperience);
        }

        // GET: EducationExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationExperience = await _context.EducationExperience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationExperience == null)
            {
                return NotFound();
            }

            return View(educationExperience);
        }

        // POST: EducationExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationExperience = await _context.EducationExperience.FindAsync(id);
            _context.EducationExperience.Remove(educationExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExperienceExists(int id)
        {
            return _context.EducationExperience.Any(e => e.Id == id);
        }
    }
}
