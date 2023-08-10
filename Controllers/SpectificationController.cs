using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class spectificationController : BaseController<Spectification> { 

        private readonly IBaseRepository<Spectification> _repository;
    private readonly ISpectificationRepository _spectificationRepository;

        public spectificationController(IBaseRepository<Spectification> repository, ISpectificationRepository spectificationRepository) : base(repository)
        {
            _spectificationRepository = spectificationRepository;

        }

        // GET: /spectification
        public async Task<IActionResult> Index()
        {
            var spectification = await _spectificationRepository.GetAllAsync();
            return View(spectification);
        }

        // GET: /spectification/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: /spectification/Create
        [HttpPost]
        public async Task<IActionResult> Create(Spectification spectification)
        {
            var result = await _spectificationRepository.CreateAsync(spectification);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }
        }

        // GET: /spectification/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var spectification = await _spectificationRepository.GetByIdAsync(id);
            if (spectification == null)
            {
                return NotFound();
            }
            return View(spectification);
        }

        // POST: /spectification/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Spectification spectification)
        {
            if (id != spectification.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _spectificationRepository.UpdateAsync(spectification);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(spectification);
        }

        // GET: /spectification/Delete/{id}
        public async Task<IActionResult> DeleteAsync(int id)
        {
            // Code để lấy spectification có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            var spectification = await _spectificationRepository.GetByIdAsync(id);
            if (spectification == null)
            {
                return NotFound();
            }
            return View(spectification);
        }

        // POST: /spectification/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Code để xóa spectification có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            var spectification = await _spectificationRepository.GetByIdAsync(id);
            if (spectification == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _spectificationRepository.DeleteAsync(spectification);
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

        // Code các phương thức để truy cập, thao tác dữ liệu từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác) ở đây
        // Ví dụ:
        private Spectification GetspectificationByIdFromDataSource(int id)
        {
            // Code để lấy spectification có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // return dbContext.spectifications.FirstOrDefault(s => s.Id == id);
            return null;
        }

        private List<Spectification> GetspectificationsFromDataSource()
        {
            // Code để lấy danh sách các spectification từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // return dbContext.spectifications.ToList();
            return new List<Spectification>();
        }

        private void SavespectificationToDataSource(Spectification spectification)
        {
            // Code để lưu spectification vào nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // dbContext.spectifications.Add(spectification);
            // dbContext.SaveChanges();
        }

        private void UpdatespectificationInDataSource(Spectification spectification)
        {
            // Code để cập nhật spectification trong nguồndữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // var existingspectification = dbContext.spectifications.FirstOrDefault(s => s.Id == spectification.Id);
            // if (existingspectification != null)
            // {
            //     existingspectification.Name = spectification.Name;
            //     dbContext.SaveChanges();
            // }
        }

        private void DeletespectificationFromDataSource(int id)
        {
            // Code để xóa spectification có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // var spectification = dbContext.spectifications.FirstOrDefault(s => s.Id == id);
            // if (spectification != null)
            // {
            //     dbContext.spectifications.Remove(spectification);
            //     dbContext.SaveChanges();
            // }
        }
    }
}