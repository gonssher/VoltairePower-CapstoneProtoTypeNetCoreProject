using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VoltairePower.Models;

namespace VoltairePower
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
            services.AddDbContext<VoltairePowerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("VoltairePowerContext"))
            );

            //In-Memory
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });


            // Add framework services
            services.AddMvc();

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookListAPI",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://CompanysWebsite.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mahboob Ali",
                        Email = string.Empty,
                        Url = new Uri("https://CompanysWebsite.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MY Company Licence",
                        Url = new Uri("https://CompanysWebsite.com/license"),
                    }
                });



            });


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
            //app.UseSwagger();
            app.UseDefaultFiles();
            app.UseSwaggerUI(c =>{c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Customer API");});
            app.UseStaticFiles();
       
            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
