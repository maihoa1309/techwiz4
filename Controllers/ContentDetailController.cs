using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{

    public class ContentDetailController : BaseController<ContentDetail>
    {
        private readonly IBaseRepository<ContentDetail> _repository;
        private readonly IContentDetailRepository _contentDetailRepository;
        
        public ContentDetailController(IBaseRepository<ContentDetail> repository, IContentDetailRepository contentDetailRepository) : base(repository)

        {

            _contentDetailRepository = contentDetailRepository;
        }

        // GET: api/ContentDetail

        public async Task<IActionResult> Index()
        {
            var contentDetails = await _contentDetailRepository.GetAllAsync();
            return View(contentDetails);
        }


        // GET: api/ContentDetail/5
        public async Task<IActionResult> Details(int id)
        {
            var contentDetails = await _contentDetailRepository.GetByIdAsync(id);
            if (contentDetails == null)
            {
                return NotFound();
            }
            return View(contentDetails);
        }

        // GET: ContentDetails/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ContentDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContentDetail contentDetail)
        {
            var result = await _contentDetailRepository.CreateAsync(contentDetail);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }

        }

        // GET: ContentDetails/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var contentDetails = await _contentDetailRepository.GetByIdAsync(id);
            if (contentDetails == null)
            {
                return NotFound();
            }
            return View(contentDetails);
        }

        // POST: ContentDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContentDetail contentDetail)
        {
            if (id != contentDetail.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _contentDetailRepository.UpdateAsync(contentDetail);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(contentDetail);
        }

        // GET: ContentDetails/Delete/5
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var contentDetails = await _contentDetailRepository.GetByIdAsync(id);
            if (contentDetails == null)
            {
                return NotFound();
            }
            return View(contentDetails);
        }

        // POST: ContentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentDetails = await _contentDetailRepository.GetByIdAsync(id);
            if (contentDetails == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _contentDetailRepository.DeleteAsync(contentDetails);
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