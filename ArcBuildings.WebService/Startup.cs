using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using ArchitecturalBuildings.ApplicationServices.Repositories;
using ArchitecturalBuildings.DomainObjects.Ports;
using ArchitecturalBuildings.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryArcBuildingsRepository>(x => new InMemoryArcBuildingsRepository(
                new List<ArcBuildings> {
                    new ArcBuildings() 
                    {
                        Id = 1,
                        Name = "��� ������������� ����������������� ������",
                        Functionality = "���������������� ������",
                        Location = "������������ ��., ��.22",
                        Number = "372-4-97",
                        Date = "04.11.1997",
                        Applicant = "��� ������������� ����������������� ������"
                    },
                    new ArcBuildings()
                    {
                        Id = 2,
                        Name = "������������� ������� ������� ���������������-��������������� ������",
                        Functionality = "���������������� ������",
                        Location = "��������� ��., �.14",
                        Number = "559-4-06",
                        Date = "29.09.2006",
                        Applicant = "��� ������������"
                    },
                    new ArcBuildings()
                    {
                        Id = 3,
                        Name = "��� ������������� ��������������� ������ ����",
                        Functionality = "�������������� ����� ��� ",
                        Location = "������, ���.8�, ����.31",
                        Number = "210-2-97",
                        Date = "02.12.1997",
                        Applicant = "��� ������������� ��������������� ������ ����"
                    }
            }));
            services.AddScoped<IReadOnlyArcBuildingsRepository>(x => x.GetRequiredService<InMemoryArcBuildingsRepository>());
            services.AddScoped<IArcBuildingsRepository>(x => x.GetRequiredService<InMemoryArcBuildingsRepository>());
         
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
