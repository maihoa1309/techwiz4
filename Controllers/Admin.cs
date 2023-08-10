using Microsoft.AspNetCore.Mvc;

namespace StreamTrace.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
