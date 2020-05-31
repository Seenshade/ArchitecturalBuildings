using System.Threading.Tasks;
using System.Collections.Generic;
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
            IEnumerable<DomainObjects.ArcBuildings> arcBuildings = null;
            if (request.ArcBuildingId != null)
            {
                var arcBuilding = await _readOnlyArcBuildingsRepository.GetArcBuilding(request.ArcBuildingId.Value);
                arcBuildings = (arcBuildings != null) ? new List<DomainObjects.ArcBuildings>() { arcBuilding } : new List<DomainObjects.ArcBuildings>();               
            } 
            else
            {
                arcBuildings = await _readOnlyArcBuildingsRepository.GetAllArcBuildings();
            }
            outputPort.Handle(new GetArcBuildingsListUseCaseResponse(arcBuildings));
            return true;
        }
    }
}
