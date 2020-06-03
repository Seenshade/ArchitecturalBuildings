using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArchitecturalBuildings.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using ArchitecturalBuildings.ApplicationServices.Ports.Gateways.Database;
using ArchitecturalBuildings.ApplicationServices.Repositories;
using ArchitecturalBuildings.DomainObjects.Ports;

namespace ArchitecturalBuildings.WebService
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
            services.AddDbContext<ArcBuildingsContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "ArcBuildings.db")}")
            );

            services.AddScoped<IArcBuildingsDatabaseGateway, ArcBuildingsEFSqliteGateway>();

            services.AddScoped<DbArcBuildingsRepository>();
            services.AddScoped<IReadOnlyArcBuildingsRepository>(x => x.GetRequiredService<DbArcBuildingsRepository>());
            services.AddScoped<IArcBuildingsRepository>(x => x.GetRequiredService<DbArcBuildingsRepository>());

            services.AddScoped<IGetArcBuildingsListUseCase, GetArcBuildingsListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
