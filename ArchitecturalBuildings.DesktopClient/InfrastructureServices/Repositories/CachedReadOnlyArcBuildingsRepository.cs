using ArchitecturalBuildings.ApplicationServices.Ports.Cache;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using ArchitecturalBuildings.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.InfrastructureServices.Repositories
{
    public class CachedReadOnlyArcBuildingsRepository : ReadOnlyArcBuildingsRepositoryDecorator
    {
        private readonly IDomainObjectsCache<ArcBuildings> _ArcBuildingsCache;

        public CachedReadOnlyArcBuildingsRepository(IReadOnlyArcBuildingsRepository routeRepository, 
                                             IDomainObjectsCache<ArcBuildings> routesCache)
            : base(routeRepository)
            => _ArcBuildingsCache = routesCache;

        public async override Task<ArcBuildings> GetBuilding(long id)
            => _ArcBuildingsCache.GetObject(id) ?? await base.GetBuilding(id);

        public async override Task<IEnumerable<ArcBuildings>> GetAllBuildings()
            => _ArcBuildingsCache.GetObjects() ?? await base.GetAllBuildings();

        public async override Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria)
            => _ArcBuildingsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryBuildings(criteria);

    }
}
