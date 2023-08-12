using Microsoft.AspNetCore.Mvc;
using StreamTrace.DTO;
using StreamTrace.Models;

namespace StreamTrace.ViewComponents
{
    public class showDataAdmin : ViewComponent
    {

        public IViewComponentResult Invoke(List<ContentDetailDTO> item, string type)
        {
            // Logic và dữ liệu của ViewComponent
            ViewBag.Type = type;
            return View(item);
        }
    }
}
