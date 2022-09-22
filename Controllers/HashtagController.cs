using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class HashtagController : Controller
    {
        myDbContext dbContext;
        public HashtagController(myDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hashtag hashtag)
        {
            dbContext.Hashtags.Add(hashtag);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
