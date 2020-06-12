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
    public class TblPackagesController : Controller
    {
        private readonly ApplicationDB _context;

        public TblPackagesController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblPackages
        public async Task<IActionResult> Index()
        {
            var applicationDB = _context.TblPackage.Include(t => t.PackageCity).Include(t => t.PackageGuide).Include(t => t.PackageHotel).Include(t => t.User);
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackage
                .Include(t => t.PackageCity)
                .Include(t => t.PackageGuide)
                .Include(t => t.PackageHotel)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (tblPackage == null)
            {
                return NotFound();
            }

            return View(tblPackage);
        }

        // GET: TblPackages/Create
        public IActionResult Create()
        {
            ViewData["PackageCityId"] = new SelectList(_context.TblCity, "CityId", "CityName");
            ViewData["PackageGuideId"] = new SelectList(_context.TblGuide, "GuideId", "GuideName");
            ViewData["PackageHotelId"] = new SelectList(_context.TblHotel, "HotelId", "HotelName");
            ViewData["UserId"] = new SelectList(_context.TblUser, "UserId", "UserFname");
            return View();
        }

        // POST: TblPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,PackageName,PackageDetail,PackageImage,PackageNoOfDays,PackageNoOfNights,PackageHotelId,PackageGuideId,PackageCityId,PackageTotalCost,PackageStatus,UserId,CreateDate,UpdateDate,IsActive,IsDelete")] TblPackage tblPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PackageCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblPackage.PackageCityId);
            ViewData["PackageGuideId"] = new SelectList(_context.TblGuide, "GuideId", "GuideName", tblPackage.PackageGuideId);
            ViewData["PackageHotelId"] = new SelectList(_context.TblHotel, "HotelId", "HotelName", tblPackage.PackageHotelId);
            ViewData["UserId"] = new SelectList(_context.TblUser, "UserId", "UserName", tblPackage.UserId);
            return View(tblPackage);
        }

        // GET: TblPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackage.FindAsync(id);
            if (tblPackage == null)
            {
                return NotFound();
            }
            ViewData["PackageCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblPackage.PackageCityId);
            ViewData["PackageGuideId"] = new SelectList(_context.TblGuide, "GuideId", "GuideId", tblPackage.PackageGuideId);
            ViewData["PackageHotelId"] = new SelectList(_context.TblHotel, "HotelId", "HotelId", tblPackage.PackageHotelId);
            ViewData["UserId"] = new SelectList(_context.TblUser, "UserId", "UserId", tblPackage.UserId);
            return View(tblPackage);
        }

        // POST: TblPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,PackageName,PackageDetail,PackageImage,PackageNoOfDays,PackageNoOfNights,PackageHotelId,PackageGuideId,PackageCityId,PackageTotalCost,PackageStatus,UserId,CreateDate,UpdateDate,IsActive,IsDelete")] TblPackage tblPackage)
        {
            if (id != tblPackage.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPackageExists(tblPackage.PackageId))
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
            ViewData["PackageCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblPackage.PackageCityId);
            ViewData["PackageGuideId"] = new SelectList(_context.TblGuide, "GuideId", "GuideId", tblPackage.PackageGuideId);
            ViewData["PackageHotelId"] = new SelectList(_context.TblHotel, "HotelId", "HotelId", tblPackage.PackageHotelId);
            ViewData["UserId"] = new SelectList(_context.TblUser, "UserId", "UserId", tblPackage.UserId);
            return View(tblPackage);
        }

        // GET: TblPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPackage = await _context.TblPackage
                .Include(t => t.PackageCity)
                .Include(t => t.PackageGuide)
                .Include(t => t.PackageHotel)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (tblPackage == null)
            {
                return NotFound();
            }

            return View(tblPackage);
        }

        // POST: TblPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPackage = await _context.TblPackage.FindAsync(id);
            _context.TblPackage.Remove(tblPackage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPackageExists(int id)
        {
            return _context.TblPackage.Any(e => e.PackageId == id);
        }
    }
}
