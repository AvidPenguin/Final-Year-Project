using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoasterCreditsCloud.Models;
using CoasterCreditsCloud.Data;

namespace CoasterCreditsCloud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Coasters = _context.Coaster.ToList();
            ViewBag.Parks = _context.Park.ToList();
            ViewBag.Credits = _context.Credit.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
