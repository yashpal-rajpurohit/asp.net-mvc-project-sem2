using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoProjectSem2.Models;

namespace DemoProjectSem2.Controllers
{
    public class TblActivitiesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblActivitiesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblActivities
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblActivity.Include(t => t.ActivityTypeNavigation);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivity = await _context.TblActivity
                .Include(t => t.ActivityTypeNavigation)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (tblActivity == null)
            {
                return NotFound();
            }

            return View(tblActivity);
        }

        // GET: TblActivities/Create
        public IActionResult Create()
        {
            ViewData["ActivityType"] = new SelectList(_context.TblActivityType, "ActivityTypeId", "ActivityTypeName");
            return View();
        }

        // POST: TblActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,ActivityName,ActivityTiming,ActivityCost,ActivityType,CreateDate,UpdateDate,IsActive,IsDelete")] TblActivity tblActivity)
        {
            if (ModelState.IsValid)
            {

                _context.Add(tblActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityType"] = new SelectList(_context.TblActivityType, "ActivityTypeId", "ActivityTypeName");
            return View(tblActivity);
        }

        // GET: TblActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivity = await _context.TblActivity.FindAsync(id);
            if (tblActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityType"] = new SelectList(_context.TblActivityType, "ActivityTypeId", "ActivityTypeName", tblActivity.ActivityType);
            return View(tblActivity);
        }

        // POST: TblActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityId,ActivityName,ActivityTiming,ActivityCost,ActivityType,CreateDate,UpdateDate,IsActive,IsDelete")] TblActivity tblActivity)
        {
            if (id != tblActivity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblActivityExists(tblActivity.ActivityId))
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
            ViewData["ActivityType"] = new SelectList(_context.TblActivityType, "ActivityTypeId", "ActivityTypeId", tblActivity.ActivityType);
            return View(tblActivity);
        }

        // GET: TblActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivity = await _context.TblActivity
                .Include(t => t.ActivityTypeNavigation)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (tblActivity == null)
            {
                return NotFound();
            }

            return View(tblActivity);
        }

        // POST: TblActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblActivity = await _context.TblActivity.FindAsync(id);
            _context.TblActivity.Remove(tblActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblActivityExists(int id)
        {
            return _context.TblActivity.Any(e => e.ActivityId == id);
        }
    }
}
