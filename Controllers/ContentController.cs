using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class ContentController<T> : Controller where T : Base
    {
        private readonly IBaseRepository<T> _repository;
        public ContentController(Repository.IBaseRepository<Content> repository, I)
        {
        }
        // GET: Content
        public async Task<IActionResult> Index()
        {
            var contents = await _repository.GetAllAsync();
            return View(contents);
        }

        // GET: Content/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    var content = await _repository.GetByIdAsync(id);
        //    if (content == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(content);
        //}

        // GET: Content/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Content/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(T entity)
        {

            var result = await _repository.CreateAsync(entity);
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
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var content = await _repository.GetByIdAsync(id);
        //    if (content == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(content);
        //}

        // POST: Content/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _repository.UpdateAsync(entity);
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
    }


    // GET: Content/Delete/5
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var content = await _repository.GetByIdAsync(id);
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
        var content = await _repository.GetByIdAsync(id);
        if (content == null)
        {
            return NotFound();
        }

        var result = await _repository.DeleteAsync(content);
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



