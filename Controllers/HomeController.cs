using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using System.Diagnostics;

namespace StreamTrace.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {

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
        public IActionResult AllMovies()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MusicDetail2()
        {
            return View("MusicDetail-2");
        }
        public IActionResult MusicDetail1()
        {
            return View("MusicDetail-1");
        }

        public IActionResult Music()
        {
            return View("music");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}