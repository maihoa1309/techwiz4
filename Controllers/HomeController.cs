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
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Movies()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }

        public IActionResult IndexTvshow()
        {
            return View();
        }

        public IActionResult TvshowStyle()
        {
            return View();
        }

        public IActionResult TvShows()
        {
            return View();
        }
        public IActionResult TvshowsAll()
        {
            return View();
        }
        public IActionResult MovieDetail()
        {
            return View();
        }
        public IActionResult TvshowsDetail()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult ContactUs()
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