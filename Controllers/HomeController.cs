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
        //Movies
            public IActionResult MoviesHome()
            {
                return View();
            }
            public IActionResult MoviesAll()
            {
                return View();
            }
            public IActionResult MovieDetail()
            {
                return View();
            }
            public IActionResult Genre()
            {
                return View();
            }
        //

        //TvShows
            public IActionResult TvshowsHome()
            {
                return View();
            }
            public IActionResult TvshowStyle()
            {
                return View();
            }
            public IActionResult TvShowsAll()
            {
                return View();
            }
            public IActionResult TvshowsDetail()
            {
                return View();
            }
        //

        //Music
            public IActionResult MusicHome()
            {
                return View();
            }
            public IActionResult SingerList()
            {
                return View();
            }
            public IActionResult MusicsAll()
                {
                    return View();
                }
            public IActionResult MusicDetail()
            {
                return View();
            }
        //

        //contact/pricing
            public IActionResult Pricing()
            {
                return View();
            }
            public IActionResult ContactUs()
            {
                return View();
            }
            public IActionResult Privacy()
            {
                return View();
            }
        //
        //user
            public IActionResult Users()
            {
                return View();
            }
        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}