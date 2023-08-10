using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class TvShowsController : Controller
    {
        public IActionResult Tvshows()
        {
            return View();
        }
    }
}
