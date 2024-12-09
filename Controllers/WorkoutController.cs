using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Data;
using TermProject.Models;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            // Set up the sorting and filtering logic
            ViewData["BodyGroupSortParam"] = String.IsNullOrEmpty(sortOrder) ? "bodygroup_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString; // Store the current search string

            var workouts = _context.Plan.Include(w => w.BodyGroup).AsQueryable();

            // Apply filtering by workout name if a search string is provided
            if (!String.IsNullOrEmpty(searchString))
            {
                workouts = workouts.Where(w => w.Name.Contains(searchString));
            }

            // Apply sorting based on the sortOrder
            switch (sortOrder)
            {
                case "bodygroup_desc":
                    workouts = workouts.OrderByDescending(w => w.BodyGroup.BodyGroupName);
                    break;
                default:
                    workouts = workouts.OrderBy(w => w.BodyGroup.BodyGroupName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Workouts>.CreateAsync(workouts.AsNoTracking(), pageNumber ?? 1, pageSize)) ;
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
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupName");
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
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupName", workouts.BodyGroupId);
            return View(workouts);
        }

        // GET: NewWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var workouts = await _context.Plan.Include(w => w.BodyGroup).FirstOrDefaultAsync(w => w.ID == id);
            if (workouts == null)
            {
                return NotFound();
            }
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupName", workouts.BodyGroupId);
            return View(workouts);
        }

        // POST: NewWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,BodyGroupId,Sets,Reps,Weight")] Workouts workouts)
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
            ViewData["BodyGroupId"] = new SelectList(_context.Set<BodyGroup>(), "BodyGroupId", "BodyGroupName", workouts.BodyGroupId);
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