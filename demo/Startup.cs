using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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
                app.UseStatusCodePagesWithReExecute("/Home/Error");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello Omar!");
                });
                endpoints.MapGet("/Hamada", new RequestDelegate(async context =>
                {
                    await context.Response.WriteAsync("Hello Hamada!");
                }));
                endpoints.MapControllerRoute(
                   name: "Default",
                   pattern: "{controller=Movies}/{action=Index}/{id:int?}"
                 );
                endpoints.MapGet("/BadRequest", async context =>
                {
                    context.Response.StatusCode = 400;
                    new BadRequestObjectResult("Error");
                });
            });
        }
    }
}
