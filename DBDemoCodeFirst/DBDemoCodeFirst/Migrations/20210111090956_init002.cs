using Microsoft.EntityFrameworkCore.Migrations;

namespace DBDemoCodeFirst.Migrations
{
    public partial class init002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestHHH",
                table: "JD_Commodity_001",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestHHH",
                table: "JD_Commodity_001");
        }
    }
}
