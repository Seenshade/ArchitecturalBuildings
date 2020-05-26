using ArchitecturalBuildings.DomainObjects;
using ArchitecturalBuildings.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitecturalBuildings.ApplicationServices.Repositories
{
    public class InMemoryArcBuildingsRepository : IReadOnlyArcBuildingsRepository,
                                                  IArcBuildingsRepository
    {
        private readonly List<DomainObjects.ArcBuildings> _arcBuildings = new List<DomainObjects.ArcBuildings>();

        public InMemoryArcBuildingsRepository(IEnumerable<DomainObjects.ArcBuildings> ArcBuildings = null)
        {
            if (ArcBuildings != null)
            {
                _arcBuildings.AddRange(ArcBuildings);
            }
        }

        public Task AddArcBuilding(DomainObjects.ArcBuildings ArcBuildings)
        {
            _arcBuildings.Add(ArcBuildings);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.ArcBuildings>> GetAllArcBuildings()
        {
            return Task.FromResult(_arcBuildings.AsEnumerable());
        }

        public Task<DomainObjects.ArcBuildings> GetArcBuilding(long id)
        {
            return Task.FromResult(_arcBuildings.Where(b => b.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.ArcBuildings>> QueryArcBuildings(ICriteria<DomainObjects.ArcBuildings> criteria)
        {
            return Task.FromResult(_arcBuildings.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveArcBuilding(DomainObjects.ArcBuildings ArcBuildings)
        {
            _arcBuildings.Remove(ArcBuildings);
            return Task.CompletedTask;
        }

        public Task UpdateArcBuilding(DomainObjects.ArcBuildings ArcBuilding)
        {
            var foundArcBuilding = GetArcBuilding(ArcBuilding.Id).Result;
            if (foundArcBuilding == null)
            {
                AddArcBuilding(ArcBuilding);
            }
            else
            {
                if (foundArcBuilding != ArcBuilding)
                {
                    _arcBuildings.Remove(foundArcBuilding);
                    _arcBuildings.Add(ArcBuilding);
                }
            }
            return Task.CompletedTask;
        }
    }
}
