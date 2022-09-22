using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;
using SocialMedia.ViewModel;

namespace SocialMedia.Controllers
{
    public class UserController : Controller
    {
        myDbContext dbContext;
        public UserController(myDbContext dbContext)
        {
           this.dbContext = dbContext;
        }
        public IActionResult profile()
        {
            int? userId= HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                return RedirectToAction("Login");
            }
            User currentUser = dbContext.Users.Where(u => u.Id == userId).Include(u => u.posts).ThenInclude(p => p.hashtag).SingleOrDefault();
            return View(currentUser);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if(user == null)
            {
                return View("myError");
            }
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginvm = new LoginVM();
            return View(loginvm);
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            User user = dbContext.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if(user == null)
            {
                LoginVM loginvm = new LoginVM();
                loginvm.Message = "Wrong Email or Password";
                return View("Login",loginvm);
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
