using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChinookASPNETWebAPI.API.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace ChinookASPNETWebAPI.API
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
            services.AddConnectionProvider(Configuration);
            services.AddAppSettings(Configuration);
            services.ConfigureRepositories();
            services.ConfigureSupervisor();
            services.ConfigureValidators();
            services.AddAPILogging();
            services.AddCORS();
            services.AddHealthChecks();
            services.AddCaching(Configuration);
            services.AddIdentity(Configuration);
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                //options.DefaultApiVersion = new ApiVersion( new DateTime( 2020, 9, 22 ) );
                //options.DefaultApiVersion =
                //  new ApiVersion(new DateTime( 2020, 9, 22 ), "LetoII", 1, "Beta");
                options.ReportApiVersions = true;
                //options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
