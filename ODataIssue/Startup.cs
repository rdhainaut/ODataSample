using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataIssue.Models;
using System.Linq;

namespace ODataIssue
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            var oDataConventionModelBuilder = new ODataConventionModelBuilder(app.ApplicationServices);
            oDataConventionModelBuilder.EnableLowerCamelCase();
            
            var peopleEntitySetConfiguration = oDataConventionModelBuilder.EntitySet<Person>("People");
            peopleEntitySetConfiguration.EntityType.HasKey(x => x.Id);
            peopleEntitySetConfiguration.EntityType.Property(x => x.UniqueIdentifier);

            var hobbiesEntitySetConfiguration = oDataConventionModelBuilder.EntitySet<Hobby>("Hobbies");
            hobbiesEntitySetConfiguration.EntityType.HasKey(x => x.Id);
            hobbiesEntitySetConfiguration.EntityType.Property(x => x.UniqueIdentifier);

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();
                routeBuilder.MapODataServiceRoute("ODataRoute", "odata", oDataConventionModelBuilder.GetEdmModel());
            });
        }
    }
}
