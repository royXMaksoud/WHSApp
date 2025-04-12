using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablsmodifyrelationwithdutystaionentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_DutyStations_DutyStationGUID1",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_DutyStationGUID1",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "DutyStationGUID1",
                table: "Warehouses");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DutyStationGUID",
                table: "Warehouses",
                column: "DutyStationGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_DutyStations_DutyStationGUID",
                table: "Warehouses",
                column: "DutyStationGUID",
                principalTable: "DutyStations",
                principalColumn: "DutyStationGUID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_DutyStations_DutyStationGUID",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_DutyStationGUID",
                table: "Warehouses");

            migrationBuilder.AddColumn<Guid>(
                name: "DutyStationGUID1",
                table: "Warehouses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DutyStationGUID1",
                table: "Warehouses",
                column: "DutyStationGUID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_DutyStations_DutyStationGUID1",
                table: "Warehouses",
                column: "DutyStationGUID1",
                principalTable: "DutyStations",
                principalColumn: "DutyStationGUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
