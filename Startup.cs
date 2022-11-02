using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyInspection_WebApp.Settings;
using PropertyInspection_WebApp.Models;
using Microsoft.AspNetCore.Http;
using PropertyInspection_WebApp.IRepository;
using PropertyInspection_WebApp.Repository;
using Microsoft.Extensions.Options;
using PropertyInspection_WebApp.Helpers.ProcessingHelper;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;

namespace PropertyInspection_WebApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mongoDbSettings = Configuration.GetSection(nameof(PIConfigurations)).Get<PIConfigurations>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                       .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                       (
                           mongoDbSettings.CONNECTIONSTRING, mongoDbSettings.NAME
                       );
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<PIConfigurations>>().Value);
            services.AddScoped<IPropertyInfoRepository, PropertyInfoRepository>();
            services.AddScoped<IFoundationRepository, FoundationRepository>();
            services.AddScoped<FoundationRepository, FoundationRepository>();


            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Secured/AccessDeniedIndex");
            });
            services.Configure<PIConfigurations>(Configuration.GetSection("PIConfigurations"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ExceptionHandling/redirectToErrorPage");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "subRoute",
                    pattern: "BuildingElements/{controller}/{action}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}

