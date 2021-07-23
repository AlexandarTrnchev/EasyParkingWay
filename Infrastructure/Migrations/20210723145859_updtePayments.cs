using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingWay.Data.Migrations
{
    public partial class updtePayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentFrom",
                table: "ParkingPlaces");

            migrationBuilder.DropColumn(
                name: "RentTo",
                table: "ParkingPlaces");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentFrom",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentTo",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentFrom",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RentTo",
                table: "Payments");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentFrom",
                table: "ParkingPlaces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RentTo",
                table: "ParkingPlaces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
