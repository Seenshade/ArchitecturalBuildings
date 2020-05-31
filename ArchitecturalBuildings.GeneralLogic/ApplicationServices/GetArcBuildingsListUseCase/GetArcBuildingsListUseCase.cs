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

        public GetArcBuildingsListUseCase(IReadOnlyArcBuildingsRepository readOnlyArcBuildingsRepository) 
            => _readOnlyArcBuildingsRepository = readOnlyArcBuildingsRepository;

        public async Task<bool> Handle(GetArcBuildingsListUseCaseRequest request, IOutputPort<GetArcBuildingsListUseCaseResponse> outputPort)
        {
            IEnumerable<ArcBuildings> buildings = null;
            if (request.BuildId != null)
            {
                var route = await _readOnlyArcBuildingsRepository.GetBuilding(request.BuildId.Value);
                buildings = (route != null) ? new List<ArcBuildings>() { route } : new List<ArcBuildings>();
                
            }
            else
            {
                buildings = await _readOnlyArcBuildingsRepository.GetAllBuildings();
            }
            outputPort.Handle(new GetArcBuildingsListUseCaseResponse(buildings));
            return true;
        }
    }
}
