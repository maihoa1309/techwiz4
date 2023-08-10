using Microsoft.AspNetCore.Mvc;
using StreamTrace.Models;

namespace StreamTrace.ViewComponents
{
    public class ContentItem : ViewComponent
    {

        public IViewComponentResult Invoke(Content item)
        {
            // Logic và dữ liệu của ViewComponent
            
            return View(item);
        }
    }
}
