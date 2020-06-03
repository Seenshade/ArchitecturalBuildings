using Microsoft.Extensions.DependencyInjection;
using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using ArchitecturalBuildings.ApplicationServices.Ports.Cache;
using ArchitecturalBuildings.ApplicationServices.Repositories;
using ArchitecturalBuildings.DesktopClient.InfrastructureServices.ViewModels;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using ArchitecturalBuildings.InfrastructureServices.Cache;
using ArchitecturalBuildings.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ArchitecturalBuildings.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<ArcBuildings>, DomainObjectsMemoryCache<ArcBuildings>>();
            services.AddSingleton<NetworkArcBuildingsRepository>(
                x => new NetworkArcBuildingsRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<ArcBuildings>>())
            );
            services.AddSingleton<CachedReadOnlyArcBuildginsRepository>(
                x => new CachedReadOnlyArcBuildginsRepository(
                    x.GetRequiredService<NetworkArcBuildingsRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<ArcBuildings>>()
                )
            );
            services.AddSingleton<IReadOnlyArcBuildingsRepository>(x => x.GetRequiredService<CachedReadOnlyArcBuildginsRepository>());
            services.AddSingleton<IGetArcBuildingsListUseCase, GetArcBuildingsListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
