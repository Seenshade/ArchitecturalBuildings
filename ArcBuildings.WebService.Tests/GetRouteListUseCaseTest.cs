using ArchitecturalBuildings.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using ArchitecturalBuildings.ApplicationServices.GetArcBuildingsListUseCase;
using System.Linq.Expressions;
using ArchitecturalBuildings.ApplicationServices.Ports;
using ArchitecturalBuildings.DomainObjects.Ports;
using ArchitecturalBuildings.ApplicationServices.Repositories;

namespace ArchitecturalBuildings.WebService.Core.Tests
{
    public class GetArcBuildingsListUseCaseTest
    {
        private InMemoryArcBuildingsRepository CreateArcBuildingsRepository()
        {
            var repo = new InMemoryArcBuildingsRepository(new List<ArcBuildings> {
                new ArcBuildings { Id = 1, Name = "ТЭО строительства административного здания", Functionality = "Административное здание", Location = "Селезневская ул., вл.22", Number = "372-4-97", Date = "04.11.1997", Applicant = "ТЭО строительства административного здания"},
                new ArcBuildings { Id = 2, Name = "Корректировка проекта фасадов административно-управленческого здания", Functionality = "Административное здание", Location = "Наметкина ул., д.14", Number = "559-4-06", Date = "29.09.2006", Applicant = "ООО «Газойлтрейд»"},
                new ArcBuildings { Id = 3, Name = "ТЭО строительства индивидуального жилого дома", Functionality = "Индивидуальный жилой дом ", Location = "Митино, мкр.8А, корп.31", Number = "210-2-97", Date = "02.12.1997", Applicant = "ТЭО строительства индивидуального жилого дома»"},
                new ArcBuildings { Id = 4, Name = "Рабочий проект строительства временного торгового павильона", Functionality = "Торговля", Location = "Шипиловский пр., площадка южного выхода из станции метро «Орехово»", Number = "286-4-98", Date = "06.07.1998", Applicant = "ООО «Анастасия и Ко»"},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllArcBuildings()
        {
            var useCase = new GetArcBuildingsListUseCase(CreateArcBuildingsRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetArcBuildingsListUseCaseRequest.CreateAllArcBuildingsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Buildings.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Buildings.Select(b => b.Id));
        }

        [Fact]
        public void TestGetAllArcBuildingsFromEmptyRepository()
        {
            var useCase = new GetArcBuildingsListUseCase(new InMemoryArcBuildingsRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetArcBuildingsListUseCaseRequest.CreateAllArcBuildingsRequest(), outputPort).Result);
            Assert.Empty(outputPort.Buildings);
        }

        [Fact]
        public void TestGetArcBuilding()
        {
            var useCase = new GetArcBuildingsListUseCase(CreateArcBuildingsRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetArcBuildingsListUseCaseRequest.CreateArcBuildingsRequest(2), outputPort).Result);
            Assert.Single(outputPort.Buildings, b => 2 == b.Id);
        }

        [Fact]
        public void TestTryGetNotExistingArcBuilding()
        {
            var useCase = new GetArcBuildingsListUseCase(CreateArcBuildingsRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetArcBuildingsListUseCaseRequest.CreateArcBuildingsRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Buildings);
        }

    }

    class OutputPort : IOutputPort<GetArcBuildingsListUseCaseResponse>
    {
        public IEnumerable<ArcBuildings> Buildings { get; private set; }

        public void Handle(GetArcBuildingsListUseCaseResponse response)
        {
            Buildings = response.Buildings;
        }
    }
}
