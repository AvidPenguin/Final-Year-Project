using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoasterCredits.Models;
using Microsoft.AspNetCore.Identity;

namespace CoasterCredits.Controllers
{
    public class CoastersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CoasterCreditsContext _context;

        public CoastersController(
            UserManager<ApplicationUser> userManager, 
            CoasterCreditsContext context)
        {
            _context = context;
        }

        // GET: Coasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coaster.ToListAsync());
        }

        // GET: Coasters/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Coasters/Create
        public IActionResult Create()
        {
            ViewBag.Parks = _context.Park.ToList();
            ViewBag.Manufacturers = _context.Manufacturer.ToList();

            return View();
        }

        // POST: Coasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoasterID,CoasterName,CoasterManufacturer,CoasterStatus,CoasterType,CoasterStyle,CoasterHeight,CoasterLength,CoasterSpeed,CoasterInversions,CoasterPark")] Coaster coaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coaster);
        }

        // GET: Coasters/Edit/5
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
            return View(coaster);
        }

        // POST: Coasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoasterID,CoasterName,CoasterManufacturer,CoasterStatus,CoasterType,CoasterStyle,CoasterHeight,CoasterLength,CoasterSpeed,CoasterInversions,CoasterPark")] Coaster coaster)
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

        // GET: Coasters/Delete/5
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

        // POST: Coasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coaster = await _context.Coaster.SingleOrDefaultAsync(m => m.CoasterID == id);
            _context.Coaster.Remove(coaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Coasters/AddCredit/5
        public async Task<IActionResult> AddCredit(int? id)
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

        // POST: Coasters/AddCredit/5
        [HttpPost, ActionName("AddCredit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCreditConfirmed(int id)
        {
            var coaster = await _context.Coaster.SingleOrDefaultAsync(m => m.CoasterID == id);



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoasterExists(int id)
        {
            return _context.Coaster.Any(e => e.CoasterID == id);
        }
    }
}
