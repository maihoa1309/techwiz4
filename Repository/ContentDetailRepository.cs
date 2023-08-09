using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IContentDetailRepository : IBaseRepository<ContentDetail>
    {


    }
    public class ContentDetailRepository : BaseRepository<ContentDetail>, IContentDetailRepository
    {
        public ContentDetailRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }
    }
}
