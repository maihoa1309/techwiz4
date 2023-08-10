using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class ContentController : BaseController <Content>
    {
        private readonly IBaseRepository<Content> _repository;
        private readonly IContentRepository _contentRepository;

        public ContentController(IBaseRepository<Content> repository, IContentRepository contentRepository) : base(repository)

        {
        
                _contentRepository = contentRepository;
        }

        // GET: Content
        public async Task<IActionResult> Index()
        {
            var contents = await _contentRepository.GetAllAsync();
            return View(contents);
        }

        // GET: Content/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // GET: Content/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Content/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Content entity)
        {

            var result = await _contentRepository.CreateAsync(entity);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }


        }

        // GET: Content/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Content/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Content entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _contentRepository.UpdateAsync(entity);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(entity);
        }




        // GET: Content/Delete/5
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }




        //POST: Content / Delete / 5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var content = await _contentRepository.GetByIdAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _contentRepository.DeleteAsync(content);
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
        public async Task<IActionResult> SearchContent(string name, int index, int size)
        {
            var contents = await _contentRepository.GetContentByName(name, index, size);
            return View(contents);
        }

        public async Task<IActionResult> GetHighestViewCount()
        {
            var contents = await _contentRepository.GetContentHighestViewCount();
            return View(contents);
        }

        public async Task<IActionResult> SortNameByASC()
        {
            var contents = await _contentRepository.SortNameByASC();
            return View(contents);
        }

        public async Task<IActionResult> SortNameByDESC()
        {
            var contents = await _contentRepository.SortNameByDESC();
            return View(contents);
        }
    }
}





