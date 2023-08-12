using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Enum;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IUserSubRepository : IBaseRepository<UserSub>
    {
        Task<bool>  RenewSub(int subType, decimal fee);

    }
    public class UserSubRepository : BaseRepository<UserSub>, IUserSubRepository
    {
        public UserSubRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }

        public async Task<bool> RenewSub(int subType, decimal fee)
        {
            var currentUser = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).GetAwaiter().GetResult();
            var userId = currentUser.Id;
            var query = from u in _context.Users.AsQueryable()
                        join ub in _context.UserSub.AsQueryable() on u.Id equals ub.UserId
                        where ub.UserId == userId
                        select ub;
            
            UserSub userSub = query.OrderByDescending(r=>r.DueDate).FirstOrDefault();
            
            UserSub newUserSub = new UserSub();
            newUserSub.Id = userSub.Id;
            newUserSub.SubscriptionId = userSub.SubscriptionId;
            newUserSub.Fee = fee;
            if (userSub.DueDate <= DateTime.Now)
            {
                newUserSub.FromDate = DateTime.Now;
                newUserSub.DueDate = DateTime.Now.AddDays(subType);
            }
            else
            {
                newUserSub.FromDate = userSub.DueDate;
                switch (subType)
                {
                    case (int)SubscriptionType.three_months:
                        newUserSub.DueDate = userSub.DueDate.Value.AddMonths(3);
                        break;
                    case (int)SubscriptionType.six_months:
                        newUserSub.DueDate = userSub.DueDate.Value.AddMonths(6);
                        break;
                    case (int)SubscriptionType.nine_months:
                        newUserSub.DueDate = userSub.DueDate.Value.AddMonths(9);
                        break;
                    //case (int)SubscriptionType.a_year:
                    //    newUserSub.DueDate = userSub.DueDate.Value.AddYears(1);
                    //    break;
                }
            }
            await _context.UserSub.AddAsync(newUserSub);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
