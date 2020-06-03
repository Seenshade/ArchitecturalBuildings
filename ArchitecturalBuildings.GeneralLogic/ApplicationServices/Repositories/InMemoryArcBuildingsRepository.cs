using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.ApplicationServices.Repositories
{
    public class InMemoryArcBuildingsRepository : IReadOnlyArcBuildingsRepository,
                                                  IArcBuildingsRepository 
    {
        private readonly List<ArcBuildings> _buildings = new List<ArcBuildings>();

        public InMemoryArcBuildingsRepository(IEnumerable<ArcBuildings> buildings = null)
        {
            if (buildings != null)
            {
                _buildings.AddRange(buildings);
            }
        }

        public Task AddArcBuilding(ArcBuildings building)
        {
            _buildings.Add(building);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
        {
            return Task.FromResult(_buildings.AsEnumerable());
        }

        public Task<ArcBuildings> GetArcBuilding(long id)
        {
            return Task.FromResult(_buildings.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria)
        {
            return Task.FromResult(_buildings.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveArcBuilding(ArcBuildings building)
        {
            _buildings.Remove(building);
            return Task.CompletedTask;
        }

        public Task UpdateArcBuilding(ArcBuildings route)
        {
            var foundRoute = GetArcBuilding(route.Id).Result;
            if (foundRoute == null)
            {
                AddArcBuilding(route);
            }
            else
            {
                if (foundRoute != route)
                {
                    _buildings.Remove(foundRoute);
                    _buildings.Add(route);
                }
            }
            return Task.CompletedTask;
        }
    }
}
