using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Data;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly WorkoutContext _context;

        public WorkoutController(WorkoutContext context)
        {
            _context = context;
        }

        // GET: NewWorkouts
        public async Task<IActionResult> Index()
        {
            var termProjectContext = _context.Plan.Include(w => w.BodyGroup);
            return View(await termProjectContext.ToListAsync());
        }

        // GET: NewWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan
                .Include(w => w.BodyGroup)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workouts == null)
            {
                return NotFound();
            }

            return View(workouts);
        }

        // GET: NewWorkouts/Create
        public IActionResult Create()
        {
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupId");
            return View();
        }

        // POST: NewWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BodyGroupId,Sets,Reps,Weight")] Workouts workouts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workouts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupId", workouts.BodyGroupId);
            return View(workouts);
        }

        // GET: NewWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan.FindAsync(id);
            if (workouts == null)
            {
                return NotFound();
            }
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupId", workouts.BodyGroupId);
            return View(workouts);
        }

        // POST: NewWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,BodyGroupName,Sets,Reps,Weight")] Workouts workouts)
        {
            if (id != workouts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workouts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutsExists(workouts.ID))
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
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupId", workouts.BodyGroupId);
            return View(workouts);
        }

        // GET: NewWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan
                .Include(w => w.BodyGroup)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workouts == null)
            {
                return NotFound();
            }

            return View(workouts);
        }

        // POST: NewWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plan == null)
            {
                return Problem("Entity set 'TermProjectContext.Workouts'  is null.");
            }
            var workouts = await _context.Plan.FindAsync(id);
            if (workouts != null)
            {
                _context.Plan.Remove(workouts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutsExists(int id)
        {
            return (_context.Plan?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}