﻿using Microsoft.AspNetCore.Identity;
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

        Task<List<Content>> SortNameByDESC();
        Task<bool> CheckStatus(string name);
        Task<bool> InsertOrUpdateContent(FormInserOrUpdateContent req, string type, int id);
        Task<List<ContentDetailDTO>> GetContentByType(string type);

        //Task<List<ContentDetailDTO>> GetContentByGeneral(string general, string value);
    }
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(ApplicationDbContext dbContext, UserManager<CustomUser> userManager, IHttpContextAccessor httpContext) : base(dbContext, userManager, httpContext) { }


        public async Task<bool> CheckStatus(string name)
        {
            bool flag = false;
            var currentUser = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).GetAwaiter().GetResult();
            if (currentUser != null)
            {
                var userId = currentUser.Id;
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
                        flag = true;
                    }
                    flag = false;
                }
                flag = true;
            }

            return flag;
        }

        public async Task<List<Content>> GetContentByName(string name, int index, int size)
        {
            var result = await FilterAsync(r => r.GetService,
                                            r => r.Name.ToLower().Contains(name.ToLower()) || r.GetService.Name.ToLower().Contains(name.ToLower()),
                                            index: index,
                                            size: size);

            return result;
        }



        public async Task<List<Content>> GetContentHighestViewCount(string type)
        {
            var result = (from c in _context.Content
                          orderby c.ViewCount
                          where c.Type.Equals(type)
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
        public async Task<List<ContentDetailDTO>> GetContentByType(string type)
        {
            List<ContentDetailDTO> listRS = new List<ContentDetailDTO>();
            var contents = await _context.Content.Where(r => r.Type.Equals(type)).ToListAsync();
            var query = await (from cd in _context.ContentDetail
                        join s in _context.Spectification on cd.SpectificationId equals s.Id
                        group cd by new { cd.ContentId, cd.SpectificationId, s.Name } into grouped
                        select new ContentSpectification
                        {
                            ContentId = grouped.Key.ContentId,
                            SpectificationId = grouped.Key.SpectificationId,
                            SpectificationName = grouped.Key.Name,
                            SpectificationValue = grouped.Select(r => r.Value).ToList()
                        }).ToListAsync();
            
            var result = (from c in contents
                          join q in query on c.Id equals q.ContentId
                          group q by c into grouped
                          select new ContentDetailDTO
                         {
                             content = grouped.Key,
                             contentSpectifications = grouped.ToList()
                         }).ToList();
            return result.ToList();


        }
        public async Task<bool> InsertOrUpdateContent(FormInserOrUpdateContent req, string type, int id)
        {
            
            var content = new Content();
            content.Name = req.name;
            content.Type = type;
            content.ImgURL = req.avatar;
            content.Trailer = req.trailer;
            content.FullVid = req.fullvideo;
            if (id> 0)
            {
                _dbSet.Update(content);
            }
            else
            {
                _dbSet.Add(content);
            }
            _context.SaveChanges();
            //Voi UPDATE => Xoa tat ca du lieu lien quan o bang ContentDetail
            if(id > 0)
            {
                var olderDeltails = _context.ContentDetail.Where(r => r.ContentId == id);
                _context.ContentDetail.RemoveRange(olderDeltails);
            }

            //Lay ra cac Spec
            if (req.director != null)
            {
                var checkDirector = _context.Spectification.Where(r => r.Name.Equals("Director")).FirstOrDefault();
                var sDirectorId = 0;
                if (checkDirector == null)
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
                
               
            }
            if (req.actor != null)
            {
                var checkActor = _context.Spectification.Where(r => r.Name.Equals("Actor")).FirstOrDefault();
                var sActorId = 0;
                if (checkActor == null)
                {
                    var sActor = new Spectification();
                    sActor.Name = "Actor";
                    _context.Spectification.Add(sActor);
                    _context.SaveChanges();
                    sActorId = sActor.Id;
                }
                else
                {
                    sActorId = checkActor.Id;
                }               
                    _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sActorId, Value = req.actor });
              
            }
          
            if (req.runtime != null)
            {
                var checkRunTime = _context.Spectification.Where(r => r.Name.Equals("RunTime")).FirstOrDefault();
                var sRunTimeId = 0;
                if (checkRunTime == null)
                {
                    var sRunTime = new Spectification();
                    sRunTime.Name = "RunTime";
                    _context.Spectification.Add(sRunTime);
                    _context.SaveChanges();
                    sRunTimeId = sRunTime.Id;
                }
                else
                {
                    sRunTimeId = checkRunTime.Id;
                }

                 _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sRunTimeId, Value = req.runtime });

            }
           

            if (req.releaseTime != null)
            {
                var checkReleaseTime = _context.Spectification.Where(r => r.Name.Equals("Relase Date")).FirstOrDefault();
                var sReleaseTimeId = 0;
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
                    sReleaseTimeId = checkReleaseTime.Id;
                }

                    _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sReleaseTimeId, Value = req.releaseTime });
                
            }

            if(req.style!= null)
            {
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
                    sStyleId = checkStyle.Id;
                }
 
                    _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sStyleId, Value = req.style });

            }
            if (req.singer != null) 
            {
                var checkSinger = _context.Spectification.Where(r => r.Name.Equals("Singer")).FirstOrDefault();
                var sSingerId = 0;
                if (checkSinger == null)
                {
                    var sSinger = new Spectification();
                    sSinger.Name = "Singer";
                    _context.Spectification.Add(sSinger);
                    _context.SaveChanges();
                    sSingerId = sSinger.Id;
                }
                else
                {
                    sSingerId = checkSinger.Id;
                }
                _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sSingerId, Value = req.singer });
            }
            if (req.languge!= null)
            {
                var checkLanguge = _context.Spectification.Where(r => r.Name.Equals("Language")).FirstOrDefault();
                var sLangugeId = 0;
                if (checkLanguge == null)
                {
                    var sLanguge = new Spectification();
                    sLanguge.Name = "Language";
                    _context.Spectification.Add(sLanguge);
                    _context.SaveChanges();
                    sLangugeId = sLanguge.Id;
                }else
                {
                    sLangugeId = checkLanguge.Id;
                }
                _context.ContentDetail.Add(new ContentDetail() { ContentId = content.Id, SpectificationId = sLangugeId, Value = req.languge });
            }

            _context.SaveChanges();


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

        public async Task<List<ContentDetailDTO>> GetContentByGeneral(string general, string value)
        {
            //List<ContentDetailDTO> listRS = new List<ContentDetailDTO>();
            ////var contents = await _context.Content.Where(r => r.Type.Equals(type)).ToListAsync();

            //var query = await (from cd in _context.ContentDetail
            //                  join s in _context.Spectification on cd.SpectificationId equals s.Id
            //                  //where s.Name.Equals()
            //                  group cd by new { cd.ContentId, cd.SpectificationId, s.Name } into grouped
            //                  select new ContentSpectification
            //                  {
            //                      ContentId = grouped.Key.ContentId,
            //                      SpectificationId = grouped.Key.SpectificationId,
            //                      SpectificationName = grouped.Key.Name,
            //                      SpectificationValue = grouped.Select(r => r.Value).ToList()
            //                  }).ToListAsync();

            throw new NotImplementedException();
        }
    }
}
