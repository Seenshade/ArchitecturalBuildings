using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<ArcBuildings> Buildings { get; }

        public GetArcBuildingsListUseCaseResponse(IEnumerable<ArcBuildings> routes) => Buildings = routes;
    }
}
