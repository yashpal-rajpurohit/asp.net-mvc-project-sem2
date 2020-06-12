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
    public class TblFoodTimeDetailsController : Controller
    {
        private readonly ApplicationDB _context;

        public TblFoodTimeDetailsController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblFoodTimeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblFoodTimeDetails.ToListAsync());
        }

        // GET: TblFoodTimeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFoodTimeDetails = await _context.TblFoodTimeDetails
                .FirstOrDefaultAsync(m => m.FoodTimeId == id);
            if (tblFoodTimeDetails == null)
            {
                return NotFound();
            }

            return View(tblFoodTimeDetails);
        }

        // GET: TblFoodTimeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblFoodTimeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodTimeId,FoodTimeName,CreateDate,UpdateDate,IsActive,IsDelete")] TblFoodTimeDetails tblFoodTimeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFoodTimeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFoodTimeDetails);
        }

        // GET: TblFoodTimeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFoodTimeDetails = await _context.TblFoodTimeDetails.FindAsync(id);
            if (tblFoodTimeDetails == null)
            {
                return NotFound();
            }
            return View(tblFoodTimeDetails);
        }

        // POST: TblFoodTimeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodTimeId,FoodTimeName,CreateDate,UpdateDate,IsActive,IsDelete")] TblFoodTimeDetails tblFoodTimeDetails)
        {
            if (id != tblFoodTimeDetails.FoodTimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFoodTimeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFoodTimeDetailsExists(tblFoodTimeDetails.FoodTimeId))
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
            return View(tblFoodTimeDetails);
        }

        // GET: TblFoodTimeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFoodTimeDetails = await _context.TblFoodTimeDetails
                .FirstOrDefaultAsync(m => m.FoodTimeId == id);
            if (tblFoodTimeDetails == null)
            {
                return NotFound();
            }

            return View(tblFoodTimeDetails);
        }

        // POST: TblFoodTimeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblFoodTimeDetails = await _context.TblFoodTimeDetails.FindAsync(id);
            _context.TblFoodTimeDetails.Remove(tblFoodTimeDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFoodTimeDetailsExists(int id)
        {
            return _context.TblFoodTimeDetails.Any(e => e.FoodTimeId == id);
        }
    }
}
