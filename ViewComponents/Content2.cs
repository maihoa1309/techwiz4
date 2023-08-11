using Microsoft.AspNetCore.Mvc;
using StreamTrace.DTO;
using StreamTrace.Models;

namespace StreamTrace.ViewComponents
{
    public class Content2 : ViewComponent
    {

        public IViewComponentResult Invoke(ContentDetailDTO item)
        {
            // Logic và dữ liệu của ViewComponent

            return View(item);
        }
    }
}
