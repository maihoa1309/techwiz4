using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface ISpectificationRepository : IBaseRepository<Spectification>
    {

    }
    public class SpectificationRepository : BaseRepository<Spectification>,ISpectificationRepository
    {
        public SpectificationRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }
    }
}

