using Microsoft.AspNetCore.Identity;
using StreamTrace.Data;
using StreamTrace.Models;

namespace StreamTrace.Repository
{
    public interface IContentRepository : IBaseRepository<Content>
    {
        Task<List<Content>> GetContentByName(string name, int index, int size);

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
    }
}
