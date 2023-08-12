using Microsoft.AspNetCore.Mvc;
using StreamTrace.DTO;
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

        public  IActionResult CreateMovie(FormInserOrUpdateContent request)
        {
             _contentRepository.InsertOrUpdateMovie(request, "movie");
            return RedirectToAction("Movies", "CMS");
        }
        public IActionResult CreateMusic(FormInserOrUpdateContent request)
        {
            _contentRepository.InsertOrUpdateMovie(request, "music");
            return RedirectToAction("Musics", "CMS");
        }
        public IActionResult CreateTvShow(FormInserOrUpdateContent request)
        {
            _contentRepository.InsertOrUpdateMovie(request, "tvshow");
            return RedirectToAction("TVShows", "CMS");
        }
    }
}


   


