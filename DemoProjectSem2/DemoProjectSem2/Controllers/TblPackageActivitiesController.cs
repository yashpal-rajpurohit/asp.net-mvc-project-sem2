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
    public class TblPackageActivitiesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblPackageActivitiesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblPackageActivities
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblPackageActivities.Include(t => t.Activity).Include(t => t.Package);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblPackageActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackageActivities = await _context.TblPackageActivities
                .Include(t => t.Activity)
                .Include(t => t.Package)
                .FirstOrDefaultAsync(m => m.PackageActivitiesId == id);
            if (tblPackageActivities == null)
            {
                return NotFound();
            }

            return View(tblPackageActivities);
        }

        // GET: TblPackageActivities/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.TblActivity, "ActivityId", "ActivityId");
            ViewData["PackageId"] = new SelectList(_context.TblPackage, "PackageId", "PackageName");
            return View();
        }

        // POST: TblPackageActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageActivitiesId,PackageId,ActivityId,CreateDate,UpdateDate,IsActive,IsDelete")] TblPackageActivities tblPackageActivities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPackageActivities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.TblActivity, "ActivityId", "ActivityId", tblPackageActivities.ActivityId);
            ViewData["PackageId"] = new SelectList(_context.TblPackage, "PackageId", "PackageName", tblPackageActivities.PackageId);
            return View(tblPackageActivities);
        }

        // GET: TblPackageActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackageActivities = await _context.TblPackageActivities.FindAsync(id);
            if (tblPackageActivities == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.TblActivity, "ActivityId", "ActivityId", tblPackageActivities.ActivityId);
            ViewData["PackageId"] = new SelectList(_context.TblPackage, "PackageId", "PackageName", tblPackageActivities.PackageId);
            return View(tblPackageActivities);
        }

        // POST: TblPackageActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageActivitiesId,PackageId,ActivityId,CreateDate,UpdateDate,IsActive,IsDelete")] TblPackageActivities tblPackageActivities)
        {
            if (id != tblPackageActivities.PackageActivitiesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPackageActivities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPackageActivitiesExists(tblPackageActivities.PackageActivitiesId))
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
            ViewData["ActivityId"] = new SelectList(_context.TblActivity, "ActivityId", "ActivityId", tblPackageActivities.ActivityId);
            ViewData["PackageId"] = new SelectList(_context.TblPackage, "PackageId", "PackageName", tblPackageActivities.PackageId);
            return View(tblPackageActivities);
        }

        // GET: TblPackageActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackageActivities = await _context.TblPackageActivities
                .Include(t => t.Activity)
                .Include(t => t.Package)
                .FirstOrDefaultAsync(m => m.PackageActivitiesId == id);
            if (tblPackageActivities == null)
            {
                return NotFound();
            }

            return View(tblPackageActivities);
        }

        // POST: TblPackageActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPackageActivities = await _context.TblPackageActivities.FindAsync(id);
            _context.TblPackageActivities.Remove(tblPackageActivities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPackageActivitiesExists(int id)
        {
            return _context.TblPackageActivities.Any(e => e.PackageActivitiesId == id);
        }
    }
}
