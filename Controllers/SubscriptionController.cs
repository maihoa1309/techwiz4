using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class SubscriptionController : BaseController<Subscription>
    {
        private readonly IBaseRepository<Subscription> _repository;
        private readonly ISubscriptionRepository  _subscriptionRepository;
        public SubscriptionController(IBaseRepository<Subscription> repository, ISubscriptionRepository subscriptionRepository) : base(repository)
        {
            _subscriptionRepository = subscriptionRepository;

        }

        // GET: /Subscription
        public async Task<IActionResult> Index()
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            return View(subscriptions);
        }

        // GET: /Subscription/Create
        public async Task<IActionResult> Create()
        {
        
            return View();
        }

        // POST: /Subscription/Create
        [HttpPost]
        public async Task<IActionResult> Create(Subscription subscription)
        {
            var result = await _subscriptionRepository.CreateAsync(subscription);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }

            
        }

        // GET: /Subscription/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: /Subscription/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Subscription subscription)
        {
            if (id != subscription.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _subscriptionRepository.UpdateAsync(subscription);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(subscription);
        }

        // GET: /Subscription/Delete/{id}
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: /Subscription/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _subscriptionRepository.DeleteAsync(subscription);
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