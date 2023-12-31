using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StreamTrace.Data;
using StreamTrace.Models;
using StreamTrace.Repository;

namespace StreamTrace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //builder.Services.AddTransient<IEmailSender, SendGrid>
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddIdentity<CustomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            // Other service configurations...

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "CustomRedirect";
            })
            .AddCookie("CustomRedirect", options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login"); // Replace with your custom login path
                options.AccessDeniedPath = new PathString("/Identity/Account/Login"); // Replace with your custom access denied path
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Optional: set the expiration time for the cookie
            });
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IContentRepository, ContentRepository>();
            builder.Services.AddScoped<IContentDetailRepository, ContentDetailRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<ISpectificationRepository, SpectificationRepository>();
            builder.Services.AddScoped< ISubscriptionRepository,SubscriptionRepository>();
            builder.Services.AddScoped<UserSubRepository, UserSubRepository>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }     
    }
}