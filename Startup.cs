using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using SmallestNumberTrifon.Contracts;
using SmallestNumberTrifon.Model;
using SmallestNumberTrifon.Services;

namespace SmallestNumberTrifon
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
            services.AddDbContext<SimpleNumberContext>(opt => opt.UseInMemoryDatabase("SimpleNumber"));
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Smallest Number" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ISettings, SettingService>();
            services.AddTransient<ICalculate, CalculationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {

                loggerFactory.AddSerilog();
                loggerFactory.AddFile("c://Logs/SmallestNumberlog-{Date}.txt");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler(configure =>
                {
                    configure.Run(async ctx =>
                    {
                        var ex = ctx.Features
                            .Get<IExceptionHandlerFeature>()
                            .Error;

                        ctx.Response.StatusCode = 500;
                        await ctx.Response.WriteAsync($"{ex.Message}");
                    });
                });
            }

            app.UseHttpsRedirection();
            loggerFactory.AddSerilog();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmallestNumber"); });
            app.UseMvc();
        }
    }
}
