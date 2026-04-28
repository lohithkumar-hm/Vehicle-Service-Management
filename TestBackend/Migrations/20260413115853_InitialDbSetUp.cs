using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    number = table.Column<string>(type: "varchar(10)", nullable: false),
                    owner_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    type = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    type = table.Column<string>(type: "varchar(100)", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vehicle_number = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_services_vehicles_vehicle_number",
                        column: x => x.vehicle_number,
                        principalTable: "vehicles",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_vehicle_number",
                table: "services",
                column: "vehicle_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
