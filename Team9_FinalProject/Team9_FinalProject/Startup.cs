using Saeed_Arifeen_HW4.DAL;
using Saeed_Arifeen_HW4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Saeed_Arifeen_HW4
{
    public class Startup

    {
        public void ConfigureServices(IServiceCollection services)
        {
            String connectionString = "Server=tcp:mis333ksp20.database.windows.net,1433;Initial Catalog=MIS333kSP20-105;Persist Security Info=False;User ID=MIS333kSP20105user;Password=!333Ksp203262;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            //NOTE: This is where you would change your password requirements

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
                { opts.User.RequireUniqueEmail = true;
                  opts.Password.RequiredLength = 6;
                  opts.Password.RequireNonAlphanumeric = false;
                  opts.Password.RequireLowercase = false;
                  opts.Password.RequireUppercase = false;
                  opts.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)

        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    } 
}
