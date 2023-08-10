using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IContentRepository : IBaseRepository<Content>
    {
        Task<List<Content>> GetContentByName(string name, int index, int size);

        Task<List<Content>> GetContentHighestViewCount();


    }
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext): base(dbContext, userManager, httpContext) { }

        public async Task<List<Content>> GetContentByName(string name, int index, int size)
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
    }
}
