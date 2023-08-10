using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;
using StreamTrace.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreamTrace.Controllers
{
    public class CustomUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.CustomUser.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _context.CustomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomUser user)
        {
            if (ModelState.IsValid)
            {
                _context.CustomUser.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.CustomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomUser user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.CustomUser.FindAsync(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.CustomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.CustomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.CustomUser.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}