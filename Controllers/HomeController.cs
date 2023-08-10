using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using System.Diagnostics;

namespace StreamTrace.Controllers
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
            return View();
        }


        public IActionResult AllMovies()
        {
            return View();
        }
        public IActionResult Tvshows()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kawaii()
        {
            return View("kawaii-song");
        }
        public IActionResult Royalty()
        {
            return View("royalty-song");
        }

        public IActionResult Music()
        {
            return View("music");
        }
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }

        public IActionResult Pricing()
        {
            return View("Pricing");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}