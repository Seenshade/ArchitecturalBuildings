using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ArchitecturalBuildings.DomainObjects.Ports
{
    public interface IReadOnlyArcBuildingsRepository
    {
        Task<ArcBuildings> GetArcBuilding(long id);

        Task<IEnumerable<ArcBuildings>> GetAllArcBuildings();

        Task<IEnumerable<ArcBuildings>> QueryArcBuildings(ICriteria<ArcBuildings> criteria);

    }

    public interface IArcBuildingsRepository
    {
        Task AddArcBuilding(ArcBuildings route);

        Task RemoveArcBuilding(ArcBuildings route);

        Task UpdateArcBuilding(ArcBuildings route);
    }
}
