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
    public class TblGuidesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblGuidesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblGuides
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblGuide.Include(t => t.GuideCity);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblGuides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuide = await _context.TblGuide
                .Include(t => t.GuideCity)
                .FirstOrDefaultAsync(m => m.GuideId == id);
            if (tblGuide == null)
            {
                return NotFound();
            }

            return View(tblGuide);
        }

        // GET: TblGuides/Create
        public IActionResult Create()
        {
            ViewData["GuideCityId"] = new SelectList(_context.TblCity, "CityId", "CityName");
            return View();
        }

        // POST: TblGuides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuideId,GuideName,GuideGender,GuideCityId,GuideContact,GuideFees,GuideStatus,CreateDate,UpdateDate,IsActive,IsDelete")] TblGuide tblGuide)
        {
            if (ModelState.IsValid)
            {
                if (tblGuide.GuideGender == "Male")
                {
                    tblGuide.GuideGender = "1";
                }
                else
                {
                    tblGuide.GuideGender = "1";
                } 
                _context.Add(tblGuide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuideCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblGuide.GuideCityId);
            return View(tblGuide);
        }

        // GET: TblGuides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuide = await _context.TblGuide.FindAsync(id);
            if (tblGuide == null)
            {
                return NotFound();
            }
            ViewData["GuideCityId"] = new SelectList(_context.TblCity, "CityId", "CityName", tblGuide.GuideCityId);
            return View(tblGuide);
        }

        // POST: TblGuides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuideId,GuideName,GuideGender,GuideCityId,GuideContact,GuideFees,GuideStatus,CreateDate,UpdateDate,IsActive,IsDelete")] TblGuide tblGuide)
        {
            if (id != tblGuide.GuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGuide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGuideExists(tblGuide.GuideId))
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
            ViewData["GuideCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblGuide.GuideCityId);
            return View(tblGuide);
        }

        // GET: TblGuides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuide = await _context.TblGuide
                .Include(t => t.GuideCity)
                .FirstOrDefaultAsync(m => m.GuideId == id);
            if (tblGuide == null)
            {
                return NotFound();
            }

            return View(tblGuide);
        }

        // POST: TblGuides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGuide = await _context.TblGuide.FindAsync(id);
            _context.TblGuide.Remove(tblGuide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblGuideExists(int id)
        {
            return _context.TblGuide.Any(e => e.GuideId == id);
        }
    }
}
