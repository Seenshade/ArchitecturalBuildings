using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitecturalBuildings.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Functionality = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Applicant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Applicant", "Date", "Functionality", "Location", "Name", "Number" },
                values: new object[] { 1L, "ТЭО строительства административного здания", "04.11.1997", "Административное здание", "Селезневская ул., вл.22", "ТЭО строительства административного здания", "372-4-97" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Applicant", "Date", "Functionality", "Location", "Name", "Number" },
                values: new object[] { 2L, "ООО «Газойлтрейд»", "29.09.2006", "Административное здание", "Наметкина ул., д.14", "Корректировка проекта фасадов административно-управленческого здания", "559-4-06" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Applicant", "Date", "Functionality", "Location", "Name", "Number" },
                values: new object[] { 3L, "ТЭО строительства индивидуального жилого дома»", "02.12.1997", "Индивидуальный жилой дом ", "Митино, мкр.8А, корп.31", "ТЭО строительства индивидуального жилого дома", "210-2-97" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Applicant", "Date", "Functionality", "Location", "Name", "Number" },
                values: new object[] { 4L, "ООО «Анастасия и Ко»", "06.07.1998", "Торговля", "Шипиловский пр., площадка южного выхода из станции метро «Орехово»", "Рабочий проект строительства временного торгового павильона", "286-4-98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
