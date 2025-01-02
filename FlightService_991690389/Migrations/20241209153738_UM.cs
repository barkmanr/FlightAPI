using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightService_991690389.Migrations
{
    /// <inheritdoc />
    public partial class UM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Flights",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Flights",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Flights");
        }
    }
}
