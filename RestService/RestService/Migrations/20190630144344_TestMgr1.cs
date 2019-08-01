using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestService.Migrations
{
    public partial class TestMgr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_MyCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkName = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MyCars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tbl_MyCars",
                columns: new[] { "Id", "MarkName", "ModelName", "Year" },
                values: new object[,]
                {
                    { 1, "Mercedes", "G55", 2016 },
                    { 2, "Nissan", "X-terra", 2003 },
                    { 3, "Toyota", "Land Crouiser 200", 2018 },
                    { 4, "Dayhatcu", "Bqumba", 1985 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_MyCars");
        }
    }
}
