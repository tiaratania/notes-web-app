using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lesson12.Models;

namespace Lesson12 //make sure you type this correctly
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                    .AddNewtonsoftJson();

            services.AddDbContext<AppDbContext>(
      options =>
         options
            .UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseMvc(

               routes =>
               {
                   routes.MapRoute(
                       name: "ViewByModuleIdLessonId",
                       template: "{moduleId}/{frLessonId:int}/{toLessonId:int?}",
                       defaults: new { controller = "RPNotes", action = "ListByModuleLesson" },
                       constraints: new { moduleId = @"[A-Za-z]\d{3}" });

                   routes.MapRoute(
                       name: "ViewByModuleId",
                       template: "{moduleId}",
                       defaults: new { controller = "RPNotes", action = "ListByModule" },
                       constraints: new { moduleId = @"[A-Za-z]\d{3}" });

                   routes.MapRoute(
                       name: "ViewByTopics",
                       template: "topic",
                       defaults: new { controller = "RPNotes", action = "TopicalIndex" });

                   routes.MapRoute(
                   name: "Search",
                       template: ":{keyPhrase}",
                       defaults: new { controller = "RPNotes", action = "Search" });

                   routes.MapRoute(
                            name: "rpNotesdefault",
                            template: "{controller=RPNotes}/{action=Index}/{id?}");

                   routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
               });
        }
    }
}

