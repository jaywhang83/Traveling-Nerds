using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Traveling_Nerds.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using System.Security.Claims;

namespace Traveling_Nerds.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IHostingEnvironment _environment;

        public LocationController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db,
            IHostingEnvironment environment
        )
        {
            _userManager = userManager;
            _db = db;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            //var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            //location.User = currentUser;
            _db.Locations.Add(location);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Details(string name)
        {
            var thisLocation = _db.Locations.FirstOrDefault(locations => locations.Name == name);
            thisLocation.Postings = _db.Postings.Where(x => x.LocationId == thisLocation.LocationId).Include(c => c.Comments).ToList();
            return View(thisLocation);
        }

        public IActionResult Edit(int id)
        {
            var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Location location)
        {
            //var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            //location.User = currentUser;
            _db.Entry(location).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public IActionResult Delete(int id)
        {
            var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            _db.Locations.Remove(thisLocation);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account"); 
        }

        public IActionResult Search()
        {
            return View(); 
        }
    }
}
