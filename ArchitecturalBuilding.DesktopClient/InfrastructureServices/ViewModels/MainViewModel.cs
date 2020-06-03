using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using ArchitecturalBuildings.ApplicationServices.Ports;
using ArchitecturalBuildings.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetArcBuildingsListUseCase _getArcBuildingsListUseCase;

        public MainViewModel(IGetArcBuildingsListUseCase getRouteListUseCase)
            => _getArcBuildingsListUseCase = getRouteListUseCase;

        private Task<bool> _loadingTask;
        private ArcBuildings _currentBuilding;
        private ObservableCollection<ArcBuildings> _buildings;

        public event PropertyChangedEventHandler PropertyChanged;

        public ArcBuildings CurrentBuilding
        {
            get => _currentBuilding; 
            set
            {
                if (_currentBuilding != value)
                {
                    _currentBuilding = value;
                    OnPropertyChanged(nameof(CurrentBuilding));
                }
            }
        }

        private async Task<bool> LoadArcBuildings()
        {
            var outputPort = new OutputPort();
            bool result = await _getArcBuildingsListUseCase.Handle(GetArcBuildingsListUseCaseRequest.CreateAllArcBuildingsRequest(), outputPort);
            if (result)
            {
                BuildingCollection = new ObservableCollection<ArcBuildings>(outputPort.Routes);
            }
            return result;
        }

        public ObservableCollection<ArcBuildings> BuildingCollection
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadArcBuildings();
                }
                
                return _buildings; 
            }
            set
            {
                if (_buildings != value)
                {
                    _buildings = value;
                    OnPropertyChanged(nameof(BuildingCollection));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetArcBuildingsListUseCaseResponse>
        {
            public IEnumerable<ArcBuildings> Routes { get; private set; }

            public void Handle(GetArcBuildingsListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Routes = new ObservableCollection<ArcBuildings>(response.Buildings);
                }
            }
        }
    }
}
