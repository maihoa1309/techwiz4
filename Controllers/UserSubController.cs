using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace.Controllers
{
    public class UserSubController : BaseController<UserSub
        >
    {

        private readonly IBaseRepository<UserSub> _repository;
        private readonly IUserSubRepository _usersubRepository;
        private readonly IContentRepository _contentRepository;

        public UserSubController(IBaseRepository<UserSub> repository, IUserSubRepository usersubRepository, IContentRepository contentRepository) : base(repository)
        {
            _usersubRepository = usersubRepository;
            _contentRepository = contentRepository;

        }
        [HttpGet]
        public async Task<IActionResult> CheckUserSubsciptionAsync(int contentId)
        {
            var result = await _contentRepository.CheckUserSubscibleAsync(contentId);
            if (result)
            {
                return Ok("Ban co the xem phim nay");
            }
            else
            {
                return BadRequest("Ban can Dang ky de xem duoc noi dung");
            }
        }
    }
}