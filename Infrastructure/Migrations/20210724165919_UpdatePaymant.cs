using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyParkingWay.Data.Migrations
{
    public partial class UpdatePaymant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");
        }
    }
}
