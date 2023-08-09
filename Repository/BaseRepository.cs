using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;


namespace StreamTrace.Repository
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<List<T>> GetAllAsync();
        //List<T> Filter();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }

    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly UserManager<CustomUser> _userManager;
        protected readonly string currentUserId = "";
        protected readonly IHttpContextAccessor _contextAccessor;
        public BaseRepository(ApplicationDbContext context, UserManager<CustomUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            var currentUser = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).GetAwaiter().GetResult();

            if (currentUser != null)
            {
                this.currentUserId = currentUser.Id;
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity != null)
            {

                entity.CreatedUser = currentUserId;
                entity.CreatedTime = DateTime.Now;
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity != null)
            {
                //_dbSet.Remove(entity);
                entity.IsDeleted = true;
                entity.DeletedUser = currentUserId;
                entity.DeletedTime = DateTime.Now;

                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;

        }

        //public List<T> Filter()
        //{

        //}

        public async Task<List<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity != null)
            {

                _dbSet.Update(entity);
                entity.UpdatedUser = currentUserId;
                entity.UpdatedTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
