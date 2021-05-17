using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTSimpleServer.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TechStart_Test.DataBase;
using TechStart_Test.services;

namespace TechStart_Test
{
    public class Startup
    {

        private string IssuerSigningKey = "IssuerSigningKey";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.DefaultApiVersion = new ApiVersion(1,0);
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    var header = new HeaderApiVersionReader("x-apiversion");
            //    options.ApiVersionReader = header;
            //});

           

            services.AddDbContext<Context>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("TechStart"));
            });

            services.AddControllers();
            services.AddMvc()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton<IAuthenticationProvider, CustomAuthenticationProvider>();
            services.AddJwtSimpleServer(option =>
            {
                option.IssuerSigningKey = IssuerSigningKey;
                //option.ClockSkew = new TimeSpan(0, 20, 0);
            }).AddJwtInMemoryRefreshTokenStore();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseRouting();
            //app.UseApiVersioning();

            app.UseJwtSimpleServer(option =>
            {
                option.IssuerSigningKey = IssuerSigningKey;
                //option.Expires = () => DateTime.UtcNow.AddMinutes(20);

            });

            app.UseAuthorization();

        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            UpdateDatabase(app);

        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<Context>();
            context.Database.Migrate();

        }

    }
}
