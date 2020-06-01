using ArchitecturalBuildings.ApplicationServices.Ports.Cache;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.InfrastructureServices.Repositories
{
    public class NetworkArcBuildingsRepository : NetworkRepositoryBase, IReadOnlyArcBuildingsRepository
    {
        private readonly IDomainObjectsCache<ArcBuildings> _routeCache;

        public NetworkArcBuildingsRepository(string host, ushort port, bool useTls, IDomainObjectsCache<ArcBuildings> routeCache)
            : base(host, port, useTls)
            => _routeCache = routeCache;

        public async Task<ArcBuildings> GetBuilding(long id)
            => CacheAndReturn(await ExecuteHttpRequest<ArcBuildings>($"routes/{id}"));

        public async Task<IEnumerable<ArcBuildings>> GetAllBuildings()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<ArcBuildings>>($"routes"), allObjects: true);

        public async Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<ArcBuildings>>($"routes"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<ArcBuildings> CacheAndReturn(IEnumerable<ArcBuildings> routes, bool allObjects = false)
        {
            if (allObjects)
            {
                _routeCache.ClearCache();
            }
            _routeCache.UpdateObjects(routes, DateTime.Now.AddDays(1), allObjects);
            return routes;
        }

        private ArcBuildings CacheAndReturn(ArcBuildings route)
        {
            _routeCache.UpdateObject(route, DateTime.Now.AddDays(1));
            return route;
        }
    }
}
