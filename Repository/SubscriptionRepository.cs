using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface ISubscription : IBaseRepository<Subscription>
    {

    }
    public class SubscriptionRepository: BaseRepository<Subscription>, ISubscription
    {
        public SubscriptionRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }
    }
}
