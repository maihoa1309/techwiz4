using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using System.Diagnostics;

namespace StreamTrace.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult AllMovies()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Detail()
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
  
