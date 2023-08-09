using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class BaseController<T> : Controller where T : Base
    {

        private readonly IBaseRepository<T> _repository;
        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        [HttpPost]
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
        [HttpPut]
        public async Task<IActionResult> Update(T entity)
        {
            var result = await _repository.UpdateAsync(entity);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(T entity)
        {
            var result = await _repository.DeleteAsync(entity);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }
        }

    }
}

