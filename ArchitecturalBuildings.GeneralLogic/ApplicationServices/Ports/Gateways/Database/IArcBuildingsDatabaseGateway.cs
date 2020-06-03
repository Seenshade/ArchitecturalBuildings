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
        Task AddBuilding(ArcBuildings building);

        Task RemoveBuilding(ArcBuildings building);

        Task UpdateBuilding(ArcBuildings building);

        Task<ArcBuildings> GetBuilding(long id);

        Task<IEnumerable<ArcBuildings>> GetAllBuildings();

        Task<IEnumerable<ArcBuildings>> QueryBuildings(Expression<Func<ArcBuildings, bool>> filter);

    }
}
