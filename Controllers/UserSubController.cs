using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class UserSubController : BaseController<UserSub
        >
    {

        private readonly IBaseRepository<UserSub> _repository;
        private readonly IUserSubRepository _usersubRepository;

        public UserSubController(IBaseRepository<UserSub> repository, IUserSubRepository usersubRepository) : base(repository)
        {
            _usersubRepository = usersubRepository;

        }

        // GET: /UserSub
        public async Task<IActionResult> Index()
        {
            var userSubs = await _usersubRepository.GetAllAsync();
            return View(userSubs);
        }

        // GET: /UserSub/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: /UserSub/Create
        [HttpPost]
        public async Task<IActionResult> Create(UserSub userSub)
        {
            var result = await _usersubRepository.CreateAsync(userSub);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }
        }

        // GET: /UserSub/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var userSub = await _usersubRepository.GetByIdAsync(id);
            if (userSub == null)
            {
                return NotFound();
            }
            return View(userSub);
        }

        // POST: /UserSub/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserSub userSub)
        {
            if (id != userSub.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _usersubRepository.UpdateAsync(userSub);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(userSub);
        }

        // GET: /UserSub/Delete/{id}
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var userSub = await _usersubRepository.GetByIdAsync(id);
            if (userSub == null)
            {
                return NotFound();
            }
            return View(userSub);
        }

        // POST: /UserSub/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSub = await _usersubRepository.GetByIdAsync(id);
            if (userSub == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _usersubRepository.DeleteAsync(userSub);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
        }
    }
}