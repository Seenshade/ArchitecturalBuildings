using ArcBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseRequest : IUseCaseRequest<GetArcBuildingsListUseCaseResponse>
    {
        public long? ArcBuildingId { get; private set; }

        private GetArcBuildingsListUseCaseRequest()
        { }

        public static GetArcBuildingsListUseCaseRequest CreateAllRoutesRequest()
        {
            return new GetArcBuildingsListUseCaseRequest();
        }
        public static GetArcBuildingsListUseCaseRequest CreateRouteRequest(long routeId)
        {
            return new GetArcBuildingsListUseCaseRequest() { ArcBuildingId = routeId };
        }
    }
}
