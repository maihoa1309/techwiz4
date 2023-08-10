using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using System.Diagnostics;

namespace StreamTrace.Controllers
{
    public class TvshowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult singleTvShows()
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
