using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingWay.Data.Migrations
{
    public partial class updateCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Parkings",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Parkings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "Parkings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Parkings");
        }
    }
}
