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

        public InMemoryArcBuildingsRepository(IEnumerable<ArcBuildings> routes = null)
        {
            if (routes != null)
            {
                _buildings.AddRange(routes);
            }
        }

        public Task AddBuilding(ArcBuildings route)
        {
            _buildings.Add(route);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ArcBuildings>> GetAllBuildings()
        {
            return Task.FromResult(_buildings.AsEnumerable());
        }

        public Task<ArcBuildings> GetBuilding(long id)
        {
            return Task.FromResult(_buildings.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria)
        {
            return Task.FromResult(_buildings.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveBuilding(ArcBuildings route)
        {
            _buildings.Remove(route);
            return Task.CompletedTask;
        }

        public Task UpdateBuilding(ArcBuildings route)
        {
            var foundRoute = GetBuilding(route.Id).Result;
            if (foundRoute == null)
            {
                AddBuilding(route);
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
