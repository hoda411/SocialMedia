using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        myDbContext dbContext;
        public PostController(myDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Post> posts = dbContext.Posts.Include(p => p.hashtag).ToList();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Create()
        {
            List<Hashtag> hashtags = dbContext.Hashtags.ToList();
            SelectList selects = new SelectList(hashtags, "Id", "Title");
            ViewBag.hashtags = selects;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post,IFormFile Img)
        {
            string path = $"wwwroot/Images/{Img.FileName}";

            FileStream fs = new FileStream(path, FileMode.Create);

            Img.CopyTo(fs);

            post.Img = $"/Images/{Img.FileName}";
            post.UserID = HttpContext.Session.GetInt32("UserId");

            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return Content("Edit");
        }
    }
}
