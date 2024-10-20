using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // GET: Workout
        public async Task<IActionResult> Index()
        {
              return _context.Plan != null ? 
                          View(await _context.Plan.ToListAsync()) :
                          Problem("Entity set 'WorkoutContext.Plan'  is null.");
        }

        // GET: Workout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workouts == null)
            {
                return NotFound();
            }

            return View(workouts);
        }

        // GET: Workout/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Sets,Reps,Weight")] Workouts workouts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workouts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workouts);
        }

        // GET: Workout/Edit/5
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
            return View(workouts);
        }

        // POST: Workout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Sets,Reps,Weight")] Workouts workouts)
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
            return View(workouts);
        }

        // GET: Workout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workouts == null)
            {
                return NotFound();
            }

            return View(workouts);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plan == null)
            {
                return Problem("Entity set 'WorkoutContext.Plan'  is null.");
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
