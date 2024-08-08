using BookFindingAndRatingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schedule.Data;

namespace SchoolShudale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("DbContextConnection")
                ?? throw new InvalidOperationException("Connection string 'DbContextConnection' not found.");
            IServiceCollection serviceCollection = builder.Services.AddDbContext<ScheduleDbContext>(options =>
            options.UseSqlServer(connectionString));

            // add the configuraion in the commin files 
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount
                    = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireNonAlphanumeric
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireLowercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequiredLength
                    = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ScheduleDbContext>();

            builder.Services.AddControllersWithViews()
                 .AddMvcOptions(options =>
                 {
                     options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();

                 });
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                 name: "areas",
                 pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                config.MapControllerRoute(
                             name: "default",
                             pattern: "{controller=Home}/{action=Index}/{id?}");
                config.MapRazorPages();
            });


            app.Run();
        }
    }
}