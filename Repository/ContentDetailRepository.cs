using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IContentDetailRepository : IBaseRepository<ContentDetail>
    {

        Task<List<Content>> GetContentByKeyword(string keyword);
    }
    public class ContentDetailRepository : BaseRepository<ContentDetail>, IContentDetailRepository
    {
        public ContentDetailRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }

        public async Task<List<Content>> GetContentByKeyword(string keyword)
        {
            //linq 
            var query = from cd in _context.ContentDetail.AsQueryable()
                        join s in _context.Spectification.AsQueryable() on cd.SpectificationId equals s.Id
                        join c in _context.Content.AsQueryable() on cd.ContentId equals c.Id
                        join sv in _context.Service.AsQueryable() on c.ServiceId equals sv.Id
                        where cd.Value.ToLower().Contains(keyword.ToLower()) ||
                              c.Name.ToLower().Contains(keyword.ToLower()) ||
                              sv.Name.ToLower().Contains(keyword.ToLower())
                        select c;
            return await query.ToListAsync();
        }
    }
}
