using ArchitecturalBuildings.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.ApplicationServices.Ports.Gateways.Database
{
    public interface IArcBuildingsDatabaseGateway
    {
        Task AddArcBuilding(ArcBuildings route);

        Task RemoveArcBuilding(ArcBuildings route);

        Task UpdateArcBuilding(ArcBuildings route);

        Task<ArcBuildings> GetArcBuilding(long id);

        Task<IEnumerable<ArcBuildings>> GetAllArcBuildings();

        Task<IEnumerable<ArcBuildings>> QueryArcBuildings(Expression<Func<ArcBuildings, bool>> filter);

    }
}
