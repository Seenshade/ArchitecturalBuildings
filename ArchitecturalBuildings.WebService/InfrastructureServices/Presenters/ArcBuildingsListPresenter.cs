using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using System.Net;
using Newtonsoft.Json;
using ArchitecturalBuildings.ApplicationServices.Ports;

namespace ArchitecturalBuildings.InfrastructureServices.Presenters
{
    public class ArcBuildingsListPresenter : IOutputPort<GetArcBuildingsListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ArcBuildingsListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetArcBuildingsListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Buildings) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
