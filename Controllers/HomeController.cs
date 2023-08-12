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
          
            public IActionResult TvShowsAll()
            {
                return View();
            }
            public IActionResult TvshowsDetail(int id)
            {
                return View(id);
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
            public IActionResult MusicDetail(int id)
            {
                return View(id);
            }
        //

   
    
        public IActionResult MovieDetail(int id)
        {
            return View(id);
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

        public IActionResult Users()
        {
            return View();
        }

        
        public IActionResult Music()
        {
            return View();
        }

       
        //contact/pricing

            public IActionResult Privacy()
            {
                return View();
            }
        //
        //user

        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}