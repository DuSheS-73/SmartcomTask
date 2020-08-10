using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartcomTask.Service;
using SmartcomTask.Domain.Repositories.Abstract;
using SmartcomTask.Domain.Repositories.EntityFramework;
using SmartcomTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SmartcomTask.Models;

namespace SmartcomTask
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // connecting config model with appsettings.json
            Configuration.Bind("AppInfo", new Config());

            // dependencies
            services.AddTransient<IItemsRepository, EFItemsRepository>();
            services.AddTransient<ICustomerRepository, EFCustomerRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<DataManager>();

            // connecting Database context
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // Identity system settings
            services.AddIdentity<ApplicationUser, ApplicationRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //// Identity system settings
            //services.AddIdentity<IdentityUser, IdentityRole<Guid>>()
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddUserManager<UserManager<User>>()
            //    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            //    .AddDefaultTokenProviders();

            // Authentication Cookies settings
            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = "smartcomAuth";
                opts.Cookie.HttpOnly = true;
                opts.LoginPath = "/account/login";
                opts.AccessDeniedPath = "/account/accessdenied";
                opts.SlidingExpiration = true;
            });

            services.AddAuthentication();

            //// Authorization policy for Admin area settings
            //services.AddAuthorization(x =>
            //{
            //    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            //});

            services.AddDistributedMemoryCache();

            services.AddSession(opts => {
                opts.IdleTimeout = TimeSpan.FromSeconds(30);
            });

            // adding Controller & Views support
            services.AddControllersWithViews(x =>
            {
                // connecting area-name with area
                // x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest).AddSessionStateTempDataProvider();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
