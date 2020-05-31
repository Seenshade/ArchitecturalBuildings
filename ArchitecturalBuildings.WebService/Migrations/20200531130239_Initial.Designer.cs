﻿// <auto-generated />
using ArchitecturalBuildings.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchitecturalBuildings.WebService.Migrations
{
    [DbContext(typeof(ArcBuildingsContext))]
    [Migration("20200531130239_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ArchitecturalBuildings.DomainObjects.ArcBuildings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Applicant")
                        .HasColumnType("TEXT");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Functionality")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BuildingDB");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Applicant = "ТЭО строительства административного здания",
                            Date = "04.11.1997",
                            Functionality = "Административное здание",
                            Location = "Селезневская ул., вл.22",
                            Name = "ТЭО строительства административного здания",
                            Number = "372-4-97"
                        },
                        new
                        {
                            Id = 2L,
                            Applicant = "ООО «Газойлтрейд»",
                            Date = "29.09.2006",
                            Functionality = "Административное здание",
                            Location = "Наметкина ул., д.14",
                            Name = "Корректировка проекта фасадов административно-управленческого здания",
                            Number = "559-4-06"
                        },
                        new
                        {
                            Id = 3L,
                            Applicant = "ТЭО строительства индивидуального жилого дома»",
                            Date = "02.12.1997",
                            Functionality = "Индивидуальный жилой дом ",
                            Location = "Митино, мкр.8А, корп.31",
                            Name = "ТЭО строительства индивидуального жилого дома",
                            Number = "210-2-97"
                        },
                        new
                        {
                            Id = 4L,
                            Applicant = "ООО «Анастасия и Ко»",
                            Date = "06.07.1998",
                            Functionality = "Торговля",
                            Location = "Шипиловский пр., площадка южного выхода из станции метро «Орехово»",
                            Name = "Рабочий проект строительства временного торгового павильона",
                            Number = "286-4-98"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
