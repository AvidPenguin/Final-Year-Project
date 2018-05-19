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
    public class CoasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coaster
        public IActionResult Index(string sortOrder)
        {
            ViewBag.Parks = _context.Park.ToList();
            var coasters = from c in _context.Coaster.ToList() select c;
            switch (sortOrder)
            {
                case "NameAsc":
                    coasters = coasters.OrderBy(c => c.CoasterName);
                    break;
                case "NameDesc":
                    coasters = coasters.OrderByDescending(c => c.CoasterName);
                    break;
                case "ParkAsc":
                    coasters = coasters.OrderBy(c => GetParkNameFromID(c.CoasterParkID));
                    break;
                case "ParkDesc":
                    coasters = coasters.OrderByDescending(c => GetParkNameFromID(c.CoasterParkID));
                    break;
                case "manufacturer_asc":
                    coasters = coasters.OrderBy(c => c.CoasterManufacturer);
                    break;
                case "manufacturer_desc":
                    coasters = coasters.OrderByDescending(c => c.CoasterManufacturer);
                    break;
                default:
                    coasters = coasters.OrderBy(c => c.CoasterName);
                    break;
            }
            return View(coasters.ToList());
        }

        private string GetParkNameFromID(int id)
        {
            string x = "unknown";
            foreach (Park p in _context.Park.ToList())
            {
                if (p.ParkID == id)
                {
                    x = p.ParkName;
                }
            }
            return x;
        }

        // GET: Coaster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Credits = _context.Credit.ToList();
            ViewBag.Parks = _context.Park.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var coaster = await _context.Coaster
                .SingleOrDefaultAsync(m => m.CoasterID == id);
            if (coaster == null)
            {
                return NotFound();
            }

            return View(coaster);
        }

        // GET: Coaster/Create
        public IActionResult Create()
        {
            ViewBag.Parks = _context.Park.ToList();
            return View();
        }

        // POST: Coaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoasterID,CoasterName,CoasterManufacturer,CoasterStatus,CoasterType,CoasterStyle,CoasterHeight,CoasterLength,CoasterSpeed,CoasterInversions,CoasterParkID")] Coaster coaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coaster);
        }

        // GET: Coaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaster = await _context.Coaster.SingleOrDefaultAsync(m => m.CoasterID == id);
            if (coaster == null)
            {
                return NotFound();
            }
            ViewBag.Parks = _context.Park.ToList();
            return View(coaster);
        }

        // POST: Coaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoasterID,CoasterName,CoasterManufacturer,CoasterStatus,CoasterType,CoasterStyle,CoasterHeight,CoasterLength,CoasterSpeed,CoasterInversions,CoasterParkID")] Coaster coaster)
        {
            if (id != coaster.CoasterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoasterExists(coaster.CoasterID))
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
            return View(coaster);
        }

        // GET: Coaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaster = await _context.Coaster
                .SingleOrDefaultAsync(m => m.CoasterID == id);
            if (coaster == null)
            {
                return NotFound();
            }

            return View(coaster);
        }

        // POST: Coaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coaster = await _context.Coaster.SingleOrDefaultAsync(m => m.CoasterID == id);
            _context.Coaster.Remove(coaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoasterExists(int id)
        {
            return _context.Coaster.Any(e => e.CoasterID == id);
        }
    }
}
