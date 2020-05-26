using ArchitecturalBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseRequest : IUseCaseRequest<GetArcBuildingsListUseCaseResponse>
    {
        public long? ArcBuildingId { get; private set; }

        private GetArcBuildingsListUseCaseRequest()
        { }

        public static GetArcBuildingsListUseCaseRequest CreateAllArcBuildingsRequest()
        {
            return new GetArcBuildingsListUseCaseRequest();
        }
        public static GetArcBuildingsListUseCaseRequest CreateArcBuildingsRequest(long BuildingId)
        {
            return new GetArcBuildingsListUseCaseRequest() { ArcBuildingId = BuildingId };
        }
    }
}
