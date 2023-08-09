using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IServiceRepository : IBaseRepository<Service>
    {

    }
    public class ServiceRepository : BaseRepository<Service> , IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }
    }

}

