using System.Diagnostics;
using LoginformSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LoginformSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var email = HttpContext.Session.GetString("Mysession");
            if (email != null)
            {
                ViewBag.email = email;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        { 
            if (HttpContext.Session.GetString("Mysession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserTbl user)
        { 
            var Userdata = context.UserTbls.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (Userdata != null)
            {
                HttpContext.Session.SetString("Mysession", Userdata.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.message = "Invalid email or password";
            }
            return View();
        }

      
       
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Mysession") != null)
            {
                HttpContext.Session.Remove("Mysession");
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
