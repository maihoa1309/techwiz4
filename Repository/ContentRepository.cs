using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IContentRepository : IBaseRepository<Content>
    {


    }
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext): base(dbContext, userManager, httpContext) { }
    }
}
