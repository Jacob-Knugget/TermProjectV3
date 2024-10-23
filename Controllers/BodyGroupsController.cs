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
    public class BodyGroupsController : Controller
    {
        private readonly WorkoutContext _context;

        public BodyGroupsController(WorkoutContext context)
        {
            _context = context;
        }

        // GET: BodyGroups
        public async Task<IActionResult> Index()
        {
              return _context.BodyGroup != null ? 
                          View(await _context.BodyGroup.ToListAsync()) :
                          Problem("Entity set 'TermProjectContext.BodyGroup'  is null.");
        }

        // GET: BodyGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BodyGroup == null)
            {
                return NotFound();
            }

            var bodyGroup = await _context.BodyGroup
                .FirstOrDefaultAsync(m => m.BodyGroupId == id);
            if (bodyGroup == null)
            {
                return NotFound();
            }

            return View(bodyGroup);
        }

        // GET: BodyGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BodyGroupId,BodyGroupName")] BodyGroup bodyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyGroup);
        }

        // GET: BodyGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BodyGroup == null)
            {
                return NotFound();
            }

            var bodyGroup = await _context.BodyGroup.FindAsync(id);
            if (bodyGroup == null)
            {
                return NotFound();
            }
            return View(bodyGroup);
        }

        // POST: BodyGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BodyGroupId,BodyGroupName")] BodyGroup bodyGroup)
        {
            if (id != bodyGroup.BodyGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyGroupExists(bodyGroup.BodyGroupId))
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
            return View(bodyGroup);
        }

        // GET: BodyGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BodyGroup == null)
            {
                return NotFound();
            }

            var bodyGroup = await _context.BodyGroup
                .FirstOrDefaultAsync(m => m.BodyGroupId == id);
            if (bodyGroup == null)
            {
                return NotFound();
            }

            return View(bodyGroup);
        }

        // POST: BodyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BodyGroup == null)
            {
                return Problem("Entity set 'TermProjectContext.BodyGroup'  is null.");
            }
            var bodyGroup = await _context.BodyGroup.FindAsync(id);
            if (bodyGroup != null)
            {
                _context.BodyGroup.Remove(bodyGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyGroupExists(int id)
        {
          return (_context.BodyGroup?.Any(e => e.BodyGroupId == id)).GetValueOrDefault();
        }
    }
}
