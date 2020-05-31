using ArchitecturalBuildings.ApplicationServices.Ports.Gateways.Database;
using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.ApplicationServices.Repositories
{
    public class DbArcBuildingsRepository : IReadOnlyArcBuildingsRepository,
                                            IArcBuildingsRepository
    {
        private readonly IArcBuildingsDatabaseGateway _databaseGateway;

        public DbArcBuildingsRepository(IArcBuildingsDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<ArcBuildings> GetBuilding(long id)
            => await _databaseGateway.GetArcBuilding(id);

        public async Task<IEnumerable<ArcBuildings>> GetAllBuildings()
            => await _databaseGateway.GetAllArcBuildings();

        public async Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria)
            => await _databaseGateway.QueryArcBuildings(criteria.Filter);

        public async Task AddBuilding(ArcBuildings route)
            => await _databaseGateway.AddArcBuilding(route);

        public async Task RemoveBuilding(ArcBuildings route)
            => await _databaseGateway.RemoveArcBuilding(route);

        public async Task UpdateBuilding(ArcBuildings route)
            => await _databaseGateway.UpdateArcBuilding(route);
    }
}
