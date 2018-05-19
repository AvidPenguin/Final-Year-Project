using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoasterCreditsCloud.Data;
using CoasterCreditsCloud.Models;

namespace CoasterCreditsCloud.Controllers
{
    public class ParkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Park
        public IActionResult Index(string sortOrder)
        {
            ViewBag.Coasters = _context.Coaster.ToList();
            var parks = from p in _context.Park.ToList() select p;
            switch (sortOrder)
            {
                case "NameAsc":
                    parks = parks.OrderBy(p => p.ParkName);
                    break;
                case "NameDesc":
                    parks = parks.OrderByDescending(p => p.ParkName);
                    break;
                case "LocationAsc":
                    parks = parks.OrderBy(p => p.ParkLocation);
                    break;
                case "LocationDesc":
                    parks = parks.OrderByDescending(p => p.ParkLocation);
                    break;
                case "CoastersAsc":
                    parks = parks.OrderBy(p => GetCoastersInPark(p.ParkID));
                    break;
                case "CoastersDesc":
                    parks = parks.OrderByDescending(p => GetCoastersInPark(p.ParkID));
                    break;
                default:
                    parks = parks.OrderBy(p => p.ParkName);
                    break;
            }
            return View(parks.ToList());
        }

        private int GetCoastersInPark(int id)
        {
            int x = 0;
            foreach (Coaster c in _context.Coaster.ToList())
            {
                if (c.CoasterParkID == id)
                {
                    x++;
                }
            }
            return x;
        }

        // GET: Park/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Coasters = _context.Coaster.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .SingleOrDefaultAsync(m => m.ParkID == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Park/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Park/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkID,ParkName,ParkLocation,ParkLatitude,ParkLongitude")] Park park)
        {
            if (ModelState.IsValid)
            {
                _context.Add(park);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Park/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park.SingleOrDefaultAsync(m => m.ParkID == id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Park/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkID,ParkName,ParkLocation,ParkLatitude,ParkLongitude")] Park park)
        {
            if (id != park.ParkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(park);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.ParkID))
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
            return View(park);
        }

        // GET: Park/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .SingleOrDefaultAsync(m => m.ParkID == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Park/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var park = await _context.Park.SingleOrDefaultAsync(m => m.ParkID == id);
            _context.Park.Remove(park);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(int id)
        {
            return _context.Park.Any(e => e.ParkID == id);
        }
    }
}
