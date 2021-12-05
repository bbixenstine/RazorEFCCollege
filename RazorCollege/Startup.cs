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
using Microsoft.EntityFrameworkCore;
using RazorCollege.Data;
using Microsoft.AspNetCore.Mvc; // required for MvcOptions

namespace RazorCollege
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var myMaxModelBindingCollectionSize = Convert.ToInt32(
                Configuration["MyMaxModelBindingCollectionSize"] ?? "100");

            services.Configure<MvcOptions>(options =>
                options.MaxModelBindingCollectionSize = myMaxModelBindingCollectionSize);
            services.AddRazorPages();
            //services.AddDbContext<SchoolContext>(options =>
                    //options.UseSqlite(Configuration.GetConnectionString("SchoolContext")));
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<SchoolContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("SchoolContext")));
            }
            else
            {
                services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SchoolContext")));
            }
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
