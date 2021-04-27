using Microsoft.EntityFrameworkCore.Migrations;

namespace ClicksAndDrive.Data.Migrations
{
    public partial class UpdateElectricScooterPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Make",
                table: "ElectricScooters",
                newName: "Made");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Made",
                table: "ElectricScooters",
                newName: "Make");
        }
    }
}
