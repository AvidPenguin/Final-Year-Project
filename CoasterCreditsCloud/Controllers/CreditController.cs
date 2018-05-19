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
    public class CreditController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Credit
        public async Task<IActionResult> Index()
        {
            ViewBag.Coasters = _context.Coaster.ToList();
            ViewBag.Parks = _context.Park.ToList();
            return View(await _context.Credit.ToListAsync());
        }

        // GET: Credit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit
                .SingleOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: Credit/Create
        public IActionResult Create(int id)
        {
            ViewBag.Coasters = _context.Coaster.ToList();
            ViewBag.Parks = _context.Park.ToList();
            ViewBag.Credits = _context.Credit.ToList();
            bool validID = false;
            foreach (Coaster c in ViewBag.Coasters)
            {
                if (c.CoasterID == id)
                {
                    validID = true;
                }
            }
            if (!validID)
            {
                return NotFound();
            }
            ViewBag.ID = id;
            
            return View();


        }

        // POST: Credit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditID,Coaster,User")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(credit);
        }

        // GET: Credit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit.SingleOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: Credit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditID,Coaster,User")] Credit credit)
        {
            if (id != credit.CreditID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.CreditID))
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
            return View(credit);
        }

        // GET: Credit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Coasters = _context.Coaster.ToList();
            ViewBag.Parks = _context.Park.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credit
                .SingleOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            if(credit.User != User.Identity.Name)
            {
                if(User.Identity.Name != "admin@ccc.com")
                {
                    return NotFound();
                }
            }

            return View(credit);
        }

        // POST: Credit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credit.SingleOrDefaultAsync(m => m.CreditID == id);
            _context.Credit.Remove(credit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credit.Any(e => e.CreditID == id);
        }
    }
}
