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
    public class TblCitiesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblCitiesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblCities
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblCity.Include(t => t.State);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await _context.TblCity
                .Include(t => t.State)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (tblCity == null)
            {
                return NotFound();
            }

            return View(tblCity);
        }

        // GET: TblCities/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.TblState, "StateId", "StateName");
            return View();
        }

        // POST: TblCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,StateId,CreateDate,UpdateDate,IsActive,IsDelete")] TblCity tblCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.TblState, "StateId", "StateName", tblCity.StateId);
            return View(tblCity);
        }

        // GET: TblCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await _context.TblCity.FindAsync(id);
            if (tblCity == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.TblState, "StateId", "StateName", tblCity.StateId);
            return View(tblCity);
        }

        // POST: TblCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,StateId,CreateDate,UpdateDate,IsActive,IsDelete")] TblCity tblCity)
        {
            if (id != tblCity.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCityExists(tblCity.CityId))
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
            ViewData["StateId"] = new SelectList(_context.TblState, "StateId", "StateId", tblCity.StateId);
            return View(tblCity);
        }

        // GET: TblCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await _context.TblCity
                .Include(t => t.State)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (tblCity == null)
            {
                return NotFound();
            }

            return View(tblCity);
        }

        // POST: TblCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCity = await _context.TblCity.FindAsync(id);
            _context.TblCity.Remove(tblCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCityExists(int id)
        {
            return _context.TblCity.Any(e => e.CityId == id);
        }
    }
}
