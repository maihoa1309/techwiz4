using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class TVShowsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
