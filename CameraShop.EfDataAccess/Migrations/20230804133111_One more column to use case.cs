using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraShop.EfDataAccess.Migrations
{
    public partial class Onemorecolumntousecase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UseCaseNumber",
                table: "UseCases",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseCaseNumber",
                table: "UseCases");
        }
    }
}
