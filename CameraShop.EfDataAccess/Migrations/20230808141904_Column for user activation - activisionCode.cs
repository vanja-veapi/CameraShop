using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraShop.EfDataAccess.Migrations
{
    public partial class ColumnforuseractivationactivisionCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueActivisonCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueActivisonCode",
                table: "Users");
        }
    }
}
