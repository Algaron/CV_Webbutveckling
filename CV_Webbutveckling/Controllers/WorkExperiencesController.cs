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
    public class WorkExperiencesController : Controller
    {
        private readonly CV_WebbutvecklingContext _context;

        public WorkExperiencesController(CV_WebbutvecklingContext context)
        {
            _context = context;
        }

        // GET: WorkExperiences
        public async Task<IActionResult> Index()
        {
            var workExp = from w in _context.WorkExperience
                          select w;
            workExp=workExp.OrderByDescending(w => w.DateStart);
            return View(workExp.AsNoTracking());

        }

        // GET: WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateStart,DateEnd,CompanyName,PositionName,Description")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.FindAsync(id);
            if (workExperience == null)
            {
                return NotFound();
            }
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateStart,DateEnd,CompanyName,PositionName,Description")] WorkExperience workExperience)
        {
            if (id != workExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.Id))
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
            return View(workExperience);
        }

        // GET: WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperience.FindAsync(id);
            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.Id == id);
        }
    }
}
