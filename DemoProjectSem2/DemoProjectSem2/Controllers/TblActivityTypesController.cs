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
    public class TblActivityTypesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblActivityTypesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblActivityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblActivityType.ToListAsync());
        }

        // GET: TblActivityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivityType = await _context.TblActivityType
                .FirstOrDefaultAsync(m => m.ActivityTypeId == id);
            if (tblActivityType == null)
            {
                return NotFound();
            }

            return View(tblActivityType);
        }

        // GET: TblActivityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblActivityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityTypeId,ActivityTypeName,CreateDate,UpdateDate,IsActive,IsDelete")] TblActivityType tblActivityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblActivityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblActivityType);
        }

        // GET: TblActivityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivityType = await _context.TblActivityType.FindAsync(id);
            if (tblActivityType == null)
            {
                return NotFound();
            }
            return View(tblActivityType);
        }

        // POST: TblActivityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActivityTypeId,ActivityTypeName")] TblActivityType tblActivityType)
        {
            if (id != tblActivityType.ActivityTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblActivityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblActivityTypeExists(tblActivityType.ActivityTypeId))
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
            return View(tblActivityType);
        }

        // GET: TblActivityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblActivityType = await _context.TblActivityType
                .FirstOrDefaultAsync(m => m.ActivityTypeId == id);
            if (tblActivityType == null)
            {
                return NotFound();
            }

            return View(tblActivityType);
        }

        // POST: TblActivityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblActivityType = await _context.TblActivityType.FindAsync(id);
            _context.TblActivityType.Remove(tblActivityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblActivityTypeExists(int id)
        {
            return _context.TblActivityType.Any(e => e.ActivityTypeId == id);
        }
    }
}
