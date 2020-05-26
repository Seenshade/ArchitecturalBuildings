using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.ArcBuildings> Buildings { get; }

        public GetArcBuildingsListUseCaseResponse(IEnumerable<DomainObjects.ArcBuildings> buildings) => Buildings = buildings;
    }
}
