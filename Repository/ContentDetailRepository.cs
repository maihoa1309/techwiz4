using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
