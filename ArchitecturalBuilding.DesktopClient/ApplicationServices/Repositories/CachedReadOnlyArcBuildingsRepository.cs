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

namespace ArchitecturalBuildings.ApplicationServices.Repositories
{
    public class CachedReadOnlyArcBuildginsRepository : ReadOnlyArcBuildingsRepositoryDecorator
    {
        private readonly IDomainObjectsCache<ArcBuildings> _arcbuildingsCache;

        public CachedReadOnlyArcBuildginsRepository(IReadOnlyArcBuildingsRepository buildingRepository, 
                                             IDomainObjectsCache<ArcBuildings> buildingsCache)
            : base(buildingRepository)
            => _arcbuildingsCache = buildingsCache;

        public async override Task<ArcBuildings> GetArcBuilding(long id)
            => _arcbuildingsCache.GetObject(id) ?? await base.GetArcBuilding(id);

        public async override Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
            => _arcbuildingsCache.GetObjects() ?? await base.GetAllArcBuildings();

        public async override Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria)
            => _arcbuildingsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryArcBuildings(criteria);

    }
}
