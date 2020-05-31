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
        private readonly IReadOnlyArcBuildingsRepository _ArcBuildingsRepository;

        public ReadOnlyArcBuildingsRepositoryDecorator(IReadOnlyArcBuildingsRepository routeRepository)
        {
            _ArcBuildingsRepository = routeRepository;
        }

        public virtual async Task<IEnumerable<ArcBuildings>> GetAllBuildings()
        {
            return await _ArcBuildingsRepository?.GetAllBuildings();
        }

        public virtual async Task<ArcBuildings> GetBuilding(long id)
        {
            return await _ArcBuildingsRepository?.GetBuilding(id);
        }

        public virtual async Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria)
        {
            return await _ArcBuildingsRepository?.QueryBuildings(criteria);
        }
    }
}
