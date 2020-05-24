using ArcBuildings.DomainObjects;
using ArcBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.ArcBuildings> Buildings { get; }

        public GetArcBuildingsListUseCaseResponse(IEnumerable<DomainObjects.ArcBuildings> buildings) => Buildings = buildings;
    }
}
