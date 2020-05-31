using ArchitecturalBuildings.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using ArchitecturalBuildings.ApplicationServices.Ports.Gateways.Database;

namespace ArchitecturalBuildings.InfrastructureServices.Gateways.Database
{
    public class TransportEFSqliteGateway : IArcBuildingsDatabaseGateway
    {
        private readonly ArcBuildingsContext _transportContext;

        public TransportEFSqliteGateway(ArcBuildingsContext transportContext)
            => _transportContext = transportContext;

        public async Task<ArcBuildings> GetArcBuilding(long id)
           => await _transportContext.BuildingDB.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ArcBuildings>> GetAllArcBuildings()
            => await _transportContext.BuildingDB.ToListAsync();
          
        public async Task<IEnumerable<ArcBuildings>> QueryArcBuildings(Expression<Func<ArcBuildings, bool>> filter)
            => await _transportContext.BuildingDB.Where(filter).ToListAsync();

        public async Task AddArcBuilding(ArcBuildings route)
        {
            _transportContext.BuildingDB.Add(route);
            await _transportContext.SaveChangesAsync();
        }

        public async Task UpdateArcBuilding(ArcBuildings route)
        {
            _transportContext.Entry(route).State = EntityState.Modified;
            await _transportContext.SaveChangesAsync();
        }

        public async Task RemoveArcBuilding(ArcBuildings route)
        {
            _transportContext.BuildingDB.Remove(route);
            await _transportContext.SaveChangesAsync();
        }

    }
}
