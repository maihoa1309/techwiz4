..w2222222222211111111using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(IHttpContextAccessor contextAccessor, UserManager<CustomUser>userManager, RoleManager<IdentityRole>roleManager )
        {
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> SeedingRoleAsync()
        //{
        //    var dbSeedRole = new DbSeedRole(_roleManager);
        //    await dbSeedRole.RoleData();
        //    return Ok("Seed role thanh cong");
        //}
        
    }
}
