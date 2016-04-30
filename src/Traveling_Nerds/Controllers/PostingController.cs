using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Traveling_Nerds.Models;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Traveling_Nerds.Controllers
{
    public class PostingController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostingController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }

      
        public IActionResult Create(int id)
        {
            ViewBag.ImageId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Posting posting, int id)
        {
            posting.LocationId = id;
            _db.Postings.Add(posting);
            _db.SaveChanges();
            return RedirectToAction("Details", "Location"); 
        }
    }
}
