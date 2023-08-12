using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamTrace.Data;

namespace StreamTrace.Controllers
{
    public class CMSController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CMSController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Movies()
        {
            
            return View();
        }
        public IActionResult TVShows()
        {
            return View();
        }
        public IActionResult Musics()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult User_sub()
        {
            return View();
        }
        public IActionResult Subscriptions()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Contents()
        {
            return View();
        }
        public IActionResult ContentDetail()
        {
            return View();
        }
        public IActionResult Spectification()
        {
            return View();
        }
        public IActionResult AddOrUpdateMovie(int id = 0)
        {
            return View(id);
        }
        public IActionResult AddOrUpdateTVShow(int id = 0)
        {
            return View(id);
        }
        public IActionResult AddOrUpdateMusic()
        {
            return View();
        }
        public IActionResult AddOrUpdateUser()
        {
            return View();
        }
        public IActionResult AddOrUpdateUser_sub()
        {
            return View();
        }
        public IActionResult AddOrUpdateSubscription()
        {
            return View();
        }
        public IActionResult AddOrUpdateService()
        {
            return View();
        }
        public IActionResult AddOrUpdateContent()
        {
            return View();
        }
        public IActionResult AddOrUpdateContentDetail()
        {
            return View();
        }
        public IActionResult AddOrUpdateSpectification()
        {
            return View();
        }
    }
}
