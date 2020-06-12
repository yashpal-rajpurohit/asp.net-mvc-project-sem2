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
    public class TblStatesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblStatesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblState.ToListAsync());
        }

        // GET: TblStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.TblState
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (tblState == null)
            {
                return NotFound();
            }

            return View(tblState);
        }

        // GET: TblStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateName,CreateDate,UpdateDate,IsActive,IsDelete")] TblState tblState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblState);
        }

        // GET: TblStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.TblState.FindAsync(id);
            if (tblState == null)
            {
                return NotFound();
            }
            return View(tblState);
        }

        // POST: TblStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateId,StateName,CreateDate,UpdateDate,IsActive,IsDelete")] TblState tblState)
        {
            if (id != tblState.StateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStateExists(tblState.StateId))
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
            return View(tblState);
        }

        // GET: TblStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.TblState
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (tblState == null)
            {
                return NotFound();
            }

            return View(tblState);
        }

        // POST: TblStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblState = await _context.TblState.FindAsync(id);
            _context.TblState.Remove(tblState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStateExists(int id)
        {
            return _context.TblState.Any(e => e.StateId == id);
        }
    }
}
