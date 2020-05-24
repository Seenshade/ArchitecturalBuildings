﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArcBuildings.DomainObjects;

namespace ArcBuildings.WebService.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArcBuildingsController : ControllerBase
    {
        private readonly ILogger<ArcBuildingsController> _logger;

        public ArcBuildingsController(ILogger<ArcBuildingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DomainObjects.ArcBuildings> GetAllArcBuildings()
        {
            return new List<DomainObjects.ArcBuildings>()
            {
                new DomainObjects.ArcBuildings()
                {
                     Id = 1,
                    Name = "ТЭО строительства административного здания",
                    Functionality = "Административное здание",
                    Location = "Селезневская ул., вл.22",
                    Number = "372-4-97",
                    Date = "04.11.1997",
                    Applicant = "ТЭО строительства административного здания"
                }
            };
        }
    }
}
