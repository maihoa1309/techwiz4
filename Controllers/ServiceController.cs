using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class ServiceController : BaseController<Service>
    {
        private readonly IBaseRepository<Service> _repository;
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IBaseRepository<Service> repository, IServiceRepository serviceRepository) : base(repository)
        {
            _serviceRepository = serviceRepository;

        }

        // GET: /Service
        public async Task<IActionResult> Index()
        {
            
            var contents = await _serviceRepository.GetAllAsync();
            return View(contents);
        }
            // GET: /Service/Create
            public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: /Service/Create
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            var result = await _serviceRepository.CreateAsync(service);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error!");
            }

            return View(service);
        }

        // GET: /Service/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: /Service/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Service service)
        {
            if (id !=   service.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _serviceRepository.UpdateAsync(service);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Error!");
                }
            }
            return View(service);
        }

        // GET: /Service/Delete/{id}
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            var service = await _serviceRepository.GetByIdAsync(id);
            if (    service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: /Service/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Code để xóa dịch vụ có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _serviceRepository.DeleteAsync(service);
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
        public async Task<IActionResult> SearchServiceByName(string name, int index, int size)
        {
            var services = await _serviceRepository.GetServiceByName(name, index, size);
            return View(services);
        }

        // Code các phương thức để truy cập, thao tác dữ liệu từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác) ở đây
        // Ví dụ:
        private Service GetServiceByIdFromDataSource(int id)
        {
            // Code để lấy dịch vụ có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // return dbContext.Services.FirstOrDefault(s => s.Id == id);
            return null;
        }

        private List<Service> GetServicesFromDataSource()
        {
            // Code để lấy danh sách dịch vụ từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // return dbContext.Services.ToList();
            return new List<Service>();
        }

        private void SaveServiceToDataSource(Service service)
        {
            // Code để lưu dịch vụ vào nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // dbContext.Services.Add(service);
            // dbContext.SaveChanges();
        }

        private void UpdateServiceInDataSource(Service service)
        {
            // Code để cập nhật dịch vụ trong nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // var existingService = dbContext.Services.FirstOrDefault(s => s.Id == service.Id);
            // if (existingService != null)
            // {
            //     existingService.Url_register = service.Url_register;
            //     existingService.Logo = service.Logo;
            //     existingService.Name = service.Name;
            //     dbContext.SaveChanges();
            // }
        }

        private void DeleteServiceFromDataSource(int id)
        {
            // Code để xóa dịch vụ có id tương ứng từ nguồn dữ liệu (database hoặc bất kỳ nguồn dữ liệu nào khác)
            // Ví dụ:
            // var service = dbContext.Services.FirstOrDefault(s => s.Id == id);
            // if (service != null)
            // {
            //     dbContext.Services.Remove(service);
            //     dbContext.SaveChanges();
            // }
        }
    }
}