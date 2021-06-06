using Microsoft.EntityFrameworkCore.Migrations;

namespace ClicksAndDrive.Data.Migrations
{
    public partial class AddImageUrlINOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Orders");
        }
    }
}
