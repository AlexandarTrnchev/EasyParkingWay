using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingWay.Data.Migrations
{
    public partial class UpdateParkingPlace1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "ParkingPlaces");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "ParkingPlaces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
