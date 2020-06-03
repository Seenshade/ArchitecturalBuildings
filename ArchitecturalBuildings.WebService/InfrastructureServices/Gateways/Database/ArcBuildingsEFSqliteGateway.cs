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
    public class ArcBuildingsEFSqliteGateway : IArcBuildingsDatabaseGateway
    {
        private readonly ArcBuildingsContext _arcbuildingsContext;

        public ArcBuildingsEFSqliteGateway(ArcBuildingsContext buildingContext)
            => _arcbuildingsContext = buildingContext;

        public async Task<ArcBuildings> GetBuilding(long id)
           => await _arcbuildingsContext.Buildings.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ArcBuildings>> GetAllBuildings()
            => await _arcbuildingsContext.Buildings.ToListAsync();
          
        public async Task<IEnumerable<ArcBuildings>> QueryBuildings(Expression<Func<ArcBuildings, bool>> filter)
            => await _arcbuildingsContext.Buildings.Where(filter).ToListAsync();

        public async Task AddBuilding(ArcBuildings building)
        {
            _arcbuildingsContext.Buildings.Add(building);
            await _arcbuildingsContext.SaveChangesAsync();
        }

        public async Task UpdateBuilding(ArcBuildings building)
        {
            _arcbuildingsContext.Entry(building).State = EntityState.Modified;
            await _arcbuildingsContext.SaveChangesAsync();
        }

        public async Task RemoveBuilding(ArcBuildings building)
        {
            _arcbuildingsContext.Buildings.Remove(building);
            await _arcbuildingsContext.SaveChangesAsync();
        }

    }
}
