using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Traveling_Nerds.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Traveling_Nerds.Controllers
{
    public class CommentController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }


        public IActionResult Create(int id)
        {
            ViewBag.PostId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment comment, int id)
        {
            comment.PostingId = id;
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Edit(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            //ViewBag.PostId = id;
            return View(thisComment);
        }

        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            //comment.PostingId = id;
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Delete(int id)
        {
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return View(thisComment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            //comment.User = currentUser;
            var thisComment = _db.Comments.FirstOrDefault(comments => comments.CommentId == id);
            _db.Comments.Remove(thisComment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
    }
}
