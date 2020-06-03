using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.DomainObjects.Repositories
{
    public abstract class ReadOnlyArcBuildingsRepositoryDecorator : IReadOnlyArcBuildingsRepository
    {
        private readonly IReadOnlyArcBuildingsRepository _arcbuildingsRepository;

        public ReadOnlyArcBuildingsRepositoryDecorator(IReadOnlyArcBuildingsRepository routeRepository)
        {
            _arcbuildingsRepository = routeRepository;
        }

        public virtual async Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
        {
            return await _arcbuildingsRepository?.GetAllArcBuildings();
        }

        public virtual async Task<ArcBuildings> GetArcBuilding(long id)
        {
            return await _arcbuildingsRepository?.GetArcBuilding(id);
        }

        public virtual async Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria)
        {
            return await _arcbuildingsRepository?.QueryArcBuildings(criteria);
        }
    }
}
