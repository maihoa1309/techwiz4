using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IUserSubRepository : IBaseRepository<UserSub>
    {


    }
    public class UserSubRepository : BaseRepository<UserSub>, IUserSubRepository
    {
        public UserSubRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }
    }
}
