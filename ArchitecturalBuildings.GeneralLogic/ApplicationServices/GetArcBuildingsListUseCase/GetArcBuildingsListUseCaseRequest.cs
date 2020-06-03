using ArchitecturalBuildings.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase
{
    public class GetArcBuildingsListUseCaseRequest : IUseCaseRequest<GetArcBuildingsListUseCaseResponse>
    {
        public long? BuildId { get; private set; }

        private GetArcBuildingsListUseCaseRequest()
        { }

        public static GetArcBuildingsListUseCaseRequest CreateAllArcBuildingsRequest()
        {
            return new GetArcBuildingsListUseCaseRequest();
        }

        public static GetArcBuildingsListUseCaseRequest CreateArcBuildingsRequest(long buildingId)
        {
            return new GetArcBuildingsListUseCaseRequest() { BuildId = buildingId };
        }
    }
}
