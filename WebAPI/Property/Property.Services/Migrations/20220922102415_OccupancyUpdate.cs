using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.Services.Migrations
{
    public partial class OccupancyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Occupancny",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Occupancny");
        }
    }
}
