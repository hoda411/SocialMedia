using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModel;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        Mydbcontext ob;
        public UserController(Mydbcontext ob)
        {
            this.ob = ob;
        }

        public IActionResult Profile()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if(userid == null)
            {
                return RedirectToAction("Login");
            }
            User user = ob.Users.SingleOrDefault(u => u.Id == userid); 
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User currentuser)
        {
            if (User == null)
            {
                return Content("error");
            }

            ob.Users.Add(currentuser);
            ob.SaveChanges();

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {

            VMUser login = new VMUser();
            return View(login);
        }

        [HttpPost]
        public IActionResult Login(VMUser vMUser)
        {
            User user = ob.Users.SingleOrDefault(u => u.email == vMUser.email && u.pass == vMUser.pass);

            if(user == null)
            {
                VMUser login = new VMUser();
                login.errormessage = "Email Or Password Not Corrcet";
                return View("Login", login);

            }
  HttpContext.Session.SetInt32("UserId",user.Id);

            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}