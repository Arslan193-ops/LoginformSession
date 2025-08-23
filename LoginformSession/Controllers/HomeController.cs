using System.Diagnostics;
using LoginformSession.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LoginformSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("SessionKey", "Session");
            return View();
        }

        public IActionResult About()
        {
            //if (HttpContext.Session.GetString("SessionKey") != null)
            //{
            //    ViewBag.SessionValue = HttpContext.Session.GetString("SessionKey");
            //}
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
