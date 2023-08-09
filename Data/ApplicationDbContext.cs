using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Models;

namespace StreamTrace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CustomUser> CustomUser{ get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentDetail> ContentDetail { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Spectification> Spectification { get; set; }
        public virtual DbSet<Subsription> Subsription { get; set; }
        public virtual DbSet<UserSub> UserSub { get; set; }

    }
}