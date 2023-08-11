using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class MoviesCotroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
