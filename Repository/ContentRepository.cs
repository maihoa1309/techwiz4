using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;
using System.Drawing;

namespace StreamTrace.Repository
{
    public interface IContentRepository : IBaseRepository<Content>
    {
        Task<List<Content>> GetContentByName(string name, int index, int size);
        Task<List<Content>> GetContentHighestViewCount();
        //Task<List<Content>> GetContentByType
        Task<List<Content>> SortNameByASC();
        
        Task <List<Content>> SortNameByDESC();
        Task<bool> CheckStatus(string name);


    }
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext): base(dbContext, userManager, httpContext) { }
        

        public async Task<bool> CheckStatus(string name)
        {
            bool flag = false;
            var currentUser = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).GetAwaiter().GetResult();
            if (currentUser != null)
            {
                var userId  = currentUser.Id;
                var checkContentStatus = from c in _context.Content.AsQueryable()
                                         join cd in _context.ContentDetail.AsQueryable() on c.Id equals cd.ContentId
                                         where c.Name.ToLower().Contains(name.ToLower())
                                         select cd.Status;
                if (checkContentStatus.FirstOrDefault() == 1)
                {
                    var checkUserSub = from u in _context.Users.AsQueryable()
                                       join us in _context.UserSub.AsQueryable() on u.Id equals us.UserId
                                       join sb in _context.Subsription.AsQueryable() on us.SubscriptionId equals sb.Id
                                       where u.Id.Equals(userId) && us.DueDate >= DateTime.Now
                                       select sb;
                    if (checkUserSub != null)
                    {
                        flag= true;
                    }
                    flag = false;
                }
                flag = true;
            }

            return flag;
        }

        public async Task<List<Content>> GetContentByName(string name ,int index, int size)
        {
                var result = await FilterAsync( r => r.GetService,
                                                r => r.Name.ToLower().Contains(name.ToLower()) || r.GetService.Name.ToLower().Contains(name.ToLower()), 
                                                index: index,
                                              size: size);

            

            return result;
        }

        public async Task<List<Content>> GetContentHighestViewCount()
        {
            var result = (from c in _context.Content 
                        orderby c.ViewCount 
                        select c).Take(5);
            return await result.ToListAsync();
        }

        public async Task<List<Content>> SortNameByASC()
        {
            var query = from c in _context.Content
                        orderby c.Name
                        select c;
            return await query.ToListAsync();
        }

        public async Task<List<Content>> SortNameByDESC()
        {
            var query = from c in _context.Content
                        orderby c.Name descending
                        select c;
            return await query.ToListAsync();
        }
    }
}
