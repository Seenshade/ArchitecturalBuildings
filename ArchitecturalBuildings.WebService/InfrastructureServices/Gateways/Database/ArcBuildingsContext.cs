using Microsoft.EntityFrameworkCore;
using ArchitecturalBuildings.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchitecturalBuildings.InfrastructureServices.Gateways.Database
{
    public class ArcBuildingsContext : DbContext
    {
        public DbSet<ArcBuildings> BuildingDB { get; set; }

        public ArcBuildingsContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<ArcBuildings>().HasData(
                new
                {
                    Id = 1L,
                    Name = "ТЭО строительства административного здания",
                    Functionality = "Административное здание",
                    Location = "Селезневская ул., вл.22",
                    Number = "372-4-97",
                    Date = "04.11.1997",
                    Applicant = "ТЭО строительства административного здания"
                },
                new
                {
                    Id = 2L,
                    Name = "Корректировка проекта фасадов административно-управленческого здания",
                    Functionality = "Административное здание",
                    Location = "Наметкина ул., д.14",
                    Number = "559-4-06",
                    Date = "29.09.2006",
                    Applicant = "ООО «Газойлтрейд»"
                },
                new
                {
                    Id = 3L,
                    Name = "ТЭО строительства индивидуального жилого дома",
                    Functionality = "Индивидуальный жилой дом ",
                    Location = "Митино, мкр.8А, корп.31",
                    Number = "210-2-97",
                    Date = "02.12.1997",
                    Applicant = "ТЭО строительства индивидуального жилого дома»"
                },
                new
                {
                    Id = 4L,
                    Name = "Рабочий проект строительства временного торгового павильона",
                    Functionality = "Торговля",
                    Location = "Шипиловский пр., площадка южного выхода из станции метро «Орехово»",
                    Number = "286-4-98",
                    Date = "06.07.1998",
                    Applicant = "ООО «Анастасия и Ко»"
                }
            );
        }
    }
}
