using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectYK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Controllers
{
    public class HomeController : Controller
    {        
        private DBClass db;
        public HomeController(DBClass context)
        {
            db = context;            
        }        
                
        public async Task<IActionResult> Index()
        {
            return View(await db.Events.ToListAsync());
        }

        public IActionResult AddSponsor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSponsor(Sponsor sponsor)
        {
            db.Sponsors.Add(sponsor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddType(TypeOfEvent type)
        {
            db.typeOfEvents.Add(type);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult AddPlace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPlace(Place place)
        {
            db.Places.Add(place);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event Event)
        {
            db.Events.Add(Event);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
