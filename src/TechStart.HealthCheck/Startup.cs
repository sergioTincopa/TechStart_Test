using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TechStart.HealthCheck
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


           

            services.AddHealthChecks()
                .AddUrlGroup(uri: new Uri("http://localhost:5000"),
                            name: "Api Tech Start",
                            tags: new[] { "Api", "NetCore 3.1" });


            services.AddControllers();

            services
                .AddHealthChecksUI(setup =>
                {
                    setup.SetHeaderText("Apps Diagnostics");
                    setup.SetEvaluationTimeInSeconds(5);
                    setup.SetApiMaxActiveRequests(1);
                    setup.MaximumHistoryEntriesPerEndpoint(20);

                    //One endpoint is configured in appsettings, let's add another one programatically
                    setup.AddHealthCheckEndpoint("Web Api", "/health-WepApi");

                }).AddInMemoryStorage();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksUI();

                endpoints.MapHealthChecks("/health-WepApi", new HealthCheckOptions
                {
                    Predicate = r => r.Tags.Contains("Api"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                
                //endpoints.MapDefaultControllerRoute();

            });
        }
    }
}
