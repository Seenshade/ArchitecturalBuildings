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
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly IGetArcBuildingsListUseCase _getArcBuildingsListUseCase;

        public RoutesController(ILogger<RoutesController> logger,
                                IGetArcBuildingsListUseCase getRouteListUseCase)
        {
            _logger = logger;
            _getArcBuildingsListUseCase = getRouteListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoutes()
        {
            var presenter = new ArcBuildingsListPresenter();
            await _getArcBuildingsListUseCase.Handle(GetArcBuildingsListUseCaseRequest.CreateAllArcBuildingsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetRoute(long BuildingId)
        {
            var presenter = new ArcBuildingsListPresenter();
            await _getArcBuildingsListUseCase.Handle(GetArcBuildingsListUseCaseRequest.CreateArcBuildingsRequest(BuildingId), presenter);
            return presenter.ContentResult;
        }
    }
}
