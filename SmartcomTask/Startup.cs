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
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IOrderElementRepository, EFOrderElementRepository>();
            services.AddTransient<DataManager>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            // connecting Database context
            services.AddDbContext<AppDbContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Config.ConnectionString));

            // HTTPS / HSTS configuration
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });

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


            // adding Controller & Views support
            services.AddControllersWithViews()
            .SetCompatibilityVersion(CompatibilityVersion.Latest).AddSessionStateTempDataProvider();

            // Session
            services.AddDistributedMemoryCache();
            services.AddSession();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
