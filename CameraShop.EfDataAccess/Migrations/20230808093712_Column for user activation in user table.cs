using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraShop.EfDataAccess.Migrations
{
    public partial class Columnforuseractivationinusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccountActivated",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccountActivated",
                table: "Users");
        }
    }
}
