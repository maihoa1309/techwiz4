using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class MusicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
