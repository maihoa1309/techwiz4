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
            var id = request.id;
            _contentRepository.InsertOrUpdateContent(request, "movie", id);
            return RedirectToAction("Movies", "CMS");
        }
        public IActionResult CreateMusic(FormInserOrUpdateContent request)
        {
            var id = request.id;
            _contentRepository.InsertOrUpdateContent(request, "music", id);
            return RedirectToAction("Musics", "CMS");
        }
        public IActionResult CreateTvShow(FormInserOrUpdateContent request)
        {
            var id = request.id;
            _contentRepository.InsertOrUpdateContent(request, "tvshow", id);
            return RedirectToAction("TVShows", "CMS");
        }

        public IActionResult UpdateMovie(FormInserOrUpdateContent request)
        {
            var id = request.id;
            _contentRepository.InsertOrUpdateContent(request, "tvshow", id);
            return RedirectToAction("Movies", "CMS");
        }
        public IActionResult GetMovieFromGenre( string value)
        {
            _contentRepository.GetContentByGeneral(value);
            return RedirectToAction("MoviesGenre", "Home");
        }
        public IActionResult DeleteMovie(Content content)
        {
            _contentRepository.DeleteAsync(content);
            return RedirectToAction("Movies", "CMS");
        }
        public IActionResult DeleteMusic(Content content)
        {
            _contentRepository.DeleteAsync(content);
            return RedirectToAction("Musics", "CMS");
        }
        public IActionResult DeleteTVShow(Content content)
        {
            _contentRepository.DeleteAsync(content);
            return RedirectToAction("TVShows", "CMS");
        }

    }
}


   


