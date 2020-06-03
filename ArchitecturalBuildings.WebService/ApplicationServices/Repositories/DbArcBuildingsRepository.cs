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

        public async Task<ArcBuildings> GetArcBuilding(long id)
            => await _databaseGateway.GetBuilding(id);

        public async Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
            => await _databaseGateway.GetAllBuildings();

        public async Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria)
            => await _databaseGateway.QueryBuildings(criteria.Filter);

        public async Task AddArcBuilding(ArcBuildings building)
            => await _databaseGateway.AddBuilding(building);

        public async Task RemoveArcBuilding(ArcBuildings building)
            => await _databaseGateway.RemoveBuilding(building);

        public async Task UpdateArcBuilding(ArcBuildings building)
            => await _databaseGateway.UpdateBuilding(building);
    }
}
