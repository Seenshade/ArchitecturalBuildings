using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using ArchitecturalBuildings.InfrastructureServices.Presenters;

namespace ArchitecturalBuildings.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArcBuildingsController : ControllerBase
    {
        private readonly ILogger<ArcBuildingsController> _logger;
        private readonly IGetArcBuildingsListUseCase _getArcBuildingsListUseCase;

        public ArcBuildingsController(ILogger<ArcBuildingsController> logger,
                                IGetArcBuildingsListUseCase getArcBuildingListUseCase)
        {
            _logger = logger;
            _getArcBuildingsListUseCase = getArcBuildingListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllArcBuildings()
        {
            var presenter = new ArcBuildingsListPresenter();
            await _getArcBuildingsListUseCase.Handle(GetArcBuildingsListUseCaseRequest.CreateAllArcBuildingsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetArcBuildings(long BuildingId)
        {
            var presenter = new ArcBuildingsListPresenter();
            await _getArcBuildingsListUseCase.Handle(GetArcBuildingsListUseCaseRequest.CreateArcBuildingsRequest(BuildingId), presenter);
            return presenter.ContentResult;
        }
    }
}
