using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
