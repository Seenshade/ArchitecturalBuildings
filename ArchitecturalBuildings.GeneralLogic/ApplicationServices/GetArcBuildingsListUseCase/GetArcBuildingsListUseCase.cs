using System.Threading.Tasks;
using System.Collections.Generic;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using ArchitecturalBuildings.ApplicationServices.Ports;

namespace ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCase : IGetArcBuildingsListUseCase
    {
        private readonly IReadOnlyArcBuildingsRepository _readOnlyArcBuildingsRepository;

        public GetArcBuildingsListUseCase(IReadOnlyArcBuildingsRepository readOnlyRouteRepository) 
            => _readOnlyArcBuildingsRepository = readOnlyRouteRepository;

        public async Task<bool> Handle(GetArcBuildingsListUseCaseRequest request, IOutputPort<GetArcBuildingsListUseCaseResponse> outputPort)
        {
            IEnumerable<ArcBuildings> routes = null;
            if (request.BuildId != null)
            {
                var route = await _readOnlyArcBuildingsRepository.GetArcBuilding(request.BuildId.Value);
                routes = (route != null) ? new List<ArcBuildings>() { route } : new List<ArcBuildings>();
                
            }
            else
            {
                routes = await _readOnlyArcBuildingsRepository.GetAllArcBuildings();
            }
            outputPort.Handle(new GetArcBuildingsListUseCaseResponse(routes));
            return true;
        }
    }
}
