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
    public class TblHotelsController : Controller
    {
        private readonly ApplicationDB _context;

        public TblHotelsController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblHotels
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblHotel.Include(t => t.City).Include(t => t.FoodTime);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblHotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHotel = await _context.TblHotel
                .Include(t => t.City)
                .Include(t => t.FoodTime)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (tblHotel == null)
            {
                return NotFound();
            }

            return View(tblHotel);
        }

        // GET: TblHotels/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.TblCity, "CityId", "CityName");
            ViewData["FoodTimeId"] = new SelectList(_context.TblFoodTimeDetails, "FoodTimeId", "FoodTimeId");
            return View();
        }

        // POST: TblHotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,CityId,FoodTimeId,HotelCost,CreateDate,UpdateDate,IsActive,IsDelete")] TblHotel tblHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.TblCity, "CityId", "CityName", tblHotel.CityId);
            ViewData["FoodTimeId"] = new SelectList(_context.TblFoodTimeDetails, "FoodTimeId", "FoodTimeId", tblHotel.FoodTimeId);
            return View(tblHotel);
        }

        // GET: TblHotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHotel = await _context.TblHotel.FindAsync(id);
            if (tblHotel == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblHotel.CityId);
            ViewData["FoodTimeId"] = new SelectList(_context.TblFoodTimeDetails, "FoodTimeId", "FoodTimeId", tblHotel.FoodTimeId);
            return View(tblHotel);
        }

        // POST: TblHotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,HotelName,CityId,FoodTimeId,HotelCost,CreateDate,UpdateDate,IsActive,IsDelete")] TblHotel tblHotel)
        {
            if (id != tblHotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHotelExists(tblHotel.HotelId))
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
            ViewData["CityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblHotel.CityId);
            ViewData["FoodTimeId"] = new SelectList(_context.TblFoodTimeDetails, "FoodTimeId", "FoodTimeId", tblHotel.FoodTimeId);
            return View(tblHotel);
        }

        // GET: TblHotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHotel = await _context.TblHotel
                .Include(t => t.City)
                .Include(t => t.FoodTime)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (tblHotel == null)
            {
                return NotFound();
            }

            return View(tblHotel);
        }

        // POST: TblHotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblHotel = await _context.TblHotel.FindAsync(id);
            _context.TblHotel.Remove(tblHotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHotelExists(int id)
        {
            return _context.TblHotel.Any(e => e.HotelId == id);
        }
    }
}
