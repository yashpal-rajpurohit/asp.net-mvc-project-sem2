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
    public class TblUsersController : Controller
    {
        private readonly ApplicationDB _context;

        public TblUsersController(ApplicationDB context)
        {
            _context = context;
        }

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {

            var applicationDB = _context.TblUser.Include(t => t.UserCity);
            
            return View(await applicationDB.ToListAsync());
        }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUser
                .Include(t => t.UserCity)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            ViewData["UserCityId"] = new SelectList(_context.TblCity, "CityId", "CityName");
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserFname,UserLname,UserDob,UserGender,UserCityId,UserPassword,UserMobile,UserEmail,CreateDate,UpdateDate,IsActive,IsDelete")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                if (tblUser.UserGender == "Male")
                {
                    tblUser.UserGender = "1";
                }
                else {
                    tblUser.UserGender = "0";

                }

                _context.Add(tblUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblUser.UserCityId);
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUser.FindAsync(id);
            if (tblUser.UserGender == "Male")
            {
                tblUser.UserGender = "1";
            }
            else
            {
                tblUser.UserGender = "0";

            }

            if (tblUser == null)
            {
                return NotFound();
            }
            ViewData["UserCityId"] = new SelectList(_context.TblCity, "CityId", "CityName", tblUser.UserCityId);
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserFname,UserLname,UserDob,UserGender,UserCityId,UserPassword,UserMobile,UserEmail,CreateDate,UpdateDate,IsActive,IsDelete")] TblUser tblUser)
        {
            if (id != tblUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserExists(tblUser.UserId))
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
            ViewData["UserCityId"] = new SelectList(_context.TblCity, "CityId", "CityId", tblUser.UserCityId);
            return View(tblUser);
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await _context.TblUser
                .Include(t => t.UserCity)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: TblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUser = await _context.TblUser.FindAsync(id);
            _context.TblUser.Remove(tblUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(int id)
        {
            return _context.TblUser.Any(e => e.UserId == id);
        }
    }
}
