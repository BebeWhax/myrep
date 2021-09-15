using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Core;
using BLL.Service;
using DataLayer;
using DataLayer.Core;
using DataLayer.Repositories;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace ITHOOT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataLayer.AppContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<DeveloperEntity>, DeveloperRepository>();
            services.AddScoped<IRepository<ClientEntity>, ClientRepository>();
            services.AddScoped<IRepository<PositionEntity>, PositionRepository>();
            services.AddScoped<IRepository<ProjectEntity>, ProjectRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
