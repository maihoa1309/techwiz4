using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.DTO;
using StreamTrace.Models;
using System.Drawing;

namespace StreamTrace.Repository
{
    public interface IContentRepository : IBaseRepository<Content>
    {
        Task<List<Content>> GetContentByName(string name, int index, int size);
        Task<List<Content>> GetContentHighestViewCount(string type);
        Task<ContentDetailDTO> GetFullDetail(int id);
        Task<List<Content>> SortNameByASC();
        
        Task <List<Content>> SortNameByDESC();
        Task<bool> CheckStatus(string name);
        Task<bool> InsertOrUpdateMovie(FormInserOrUpdateContent req);


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
                var checkContentStatus = from c in _context.Content
                                         where c.Name.ToLower().Contains(name.ToLower())
                                         select c.Status;
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

       
        public async Task<List<Content>> GetContentHighestViewCount(string type )
        {
            var result = (from c in _context.Content
                          orderby c.ViewCount where c.Type.Equals(type)
                          select c).Take(7);
            return await result.ToListAsync();
        }

        public async Task<ContentDetailDTO> GetFullDetail(int id)
        {
            var result = new ContentDetailDTO();

            //Lay ra content
            var content = await GetByIdAsync(id);

            var q = from cd in _context.ContentDetail
                    join s in _context.Spectification on cd.SpectificationId equals s.Id
                    group cd by new { cd.ContentId, cd.SpectificationId, s.Name } into grouped
                    where grouped.Key.ContentId == id
                    select new ContentSpectification
                    {
                        ContentId = grouped.Key.ContentId,
                        SpectificationId = grouped.Key.SpectificationId,
                        SpectificationName = grouped.Key.Name,
                        SpectificationValue = grouped.Select(r => r.Value).ToList()

                    };
            result.content = content;
            result.contentSpectifications = await q.ToListAsync();
            return result;
        }

        public async Task<bool> InsertOrUpdateMovie(FormInserOrUpdateContent req)
        {
            var content = new Content();
            content.Name = req.name;
            content.Type = "movie";
            content.ImgURL = req.avatar;
            content.Trailer = req.trailer;
            content.FullVid = req.fullvideo;
            _dbSet.Add(content);
            _context.SaveChanges();
            //Lay ra cac Spec
            var checkDirector = _context.Spectification.Where(r => r.Name.Equals("Director")).FirstOrDefault();
            var sDirectorId = 0;
            if(checkDirector == null)
            {
                //Them 1 spec director vao
                var sDirector = new Spectification();
                sDirector.Name = "Director";
                _context.Spectification.Add(sDirector);
                _context.SaveChanges();
                sDirectorId = sDirector.Id;
            }
            else
            {
                sDirectorId = checkDirector.Id;
            }
            //Add content detail
            _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sDirectorId, Value = req.director });

            var checkActor = _context.Spectification.Where(r => r.Name.Equals("Actor")).FirstOrDefault();
            var sActorId = 0;
            if (checkActor == null)
            {
               var sActor =  new Spectification();
                sActor.Name = "Actor";
                _context.Spectification.Add(sActor); 
                _context.SaveChanges();
                sActorId = sActor.Id;
            }
            else
            {
                sActorId = checkActor.Id;
            }
            _context.ContentDetail.Add(new ContentDetail() {ContentId = content.Id, SpectificationId = sActorId, Value = req.actor });

            var checkRunTime = _context.Spectification.Where(r => r.Name.Equals("RunTime")).FirstOrDefault();
            var sRunTimeId = 0;
            if (checkRunTime == null)
            {
                var sRunTime = new Spectification();
                sRunTime.Name = "RunTime";
                _context.Spectification.Add(sRunTime); 
                _context.SaveChanges();
                sRunTimeId = sRunTime.Id;
            }else
            {
                sRunTimeId = checkRunTime.Id;
            }
            _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sRunTimeId, Value = req.runtime });

            var checkReleaseTime = _context.Spectification.Where(r => r.Name.Equals("Relase Date")).FirstOrDefault();
            var sReleaseTimeId  = 0;
            if (checkReleaseTime == null)
            {
                var sReleaseTime = new Spectification();
                sReleaseTime.Name = "Relase Date";
                _context.Spectification.Add(sReleaseTime);
                _context.SaveChanges();
                sReleaseTimeId = sReleaseTime.Id;
            }
            else
            {
                sReleaseTimeId= checkReleaseTime.Id;
            }
            _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id,SpectificationId = sReleaseTimeId,Value = req.releaseTime });

            var checkStyle = _context.Spectification.Where(r => r.Name.Equals("General")).FirstOrDefault();
            var sStyleId = 0;
            if (checkStyle == null)
            {
                var sStyle = new Spectification();
                sStyle.Name = "General";
                _context.Spectification.Add(sStyle);
                _context.SaveChanges();
                sStyleId = sStyle.Id;
            }
            else
            {
                sStyleId= checkStyle.Id;
            }
            _context.ContentDetail.Add(new ContentDetail() { ContentId= content.Id,SpectificationId = sStyleId,Value = req.style });

            return true;

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
