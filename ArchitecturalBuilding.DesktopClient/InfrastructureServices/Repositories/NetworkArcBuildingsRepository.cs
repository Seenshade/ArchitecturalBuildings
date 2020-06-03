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
        private readonly IDomainObjectsCache<ArcBuildings> _arcbuildingsCache;

        public NetworkArcBuildingsRepository(string host, ushort port, bool useTls, IDomainObjectsCache<ArcBuildings> routeCache)
            : base(host, port, useTls)
            => _arcbuildingsCache = routeCache;

        public async Task<ArcBuildings> GetArcBuilding(long id)
            => CacheAndReturn(await ExecuteHttpRequest<ArcBuildings>($"ArcBuildings/{id}"));

        public async Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<ArcBuildings>>($"ArcBuildings"), allObjects: true);

        public async Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<ArcBuildings>>($"ArcBuildings"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<ArcBuildings> CacheAndReturn(IEnumerable<ArcBuildings> routes, bool allObjects = false)
        {
            if (allObjects)
            {
                _arcbuildingsCache.ClearCache();
            }
            _arcbuildingsCache.UpdateObjects(routes, DateTime.Now.AddDays(1), allObjects);
            return routes;
        }

        private ArcBuildings CacheAndReturn(ArcBuildings route)
        {
            _arcbuildingsCache.UpdateObject(route, DateTime.Now.AddDays(1));
            return route;
        }
    }
}
