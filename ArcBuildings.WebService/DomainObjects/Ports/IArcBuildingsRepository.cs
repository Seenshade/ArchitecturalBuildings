using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ArchitecturalBuildings.DomainObjects.Ports
{
    public interface IReadOnlyArcBuildingsRepository
    {
        Task<ArcBuildings> GetBuilding(long id);

        Task<IEnumerable<ArcBuildings>> GetAllBuildings();

        Task<IEnumerable<ArcBuildings>> QueryBuildings(ICriteria<ArcBuildings> criteria);

    }

    public interface IArcBuildingsRepository
    {
        Task AddBuilding(ArcBuildings route);

        Task RemoveBuilding(ArcBuildings route);

        Task UpdateBuilding(ArcBuildings route);
    }
}
