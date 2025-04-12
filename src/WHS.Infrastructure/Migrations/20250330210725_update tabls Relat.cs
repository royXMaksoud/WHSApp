using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablsRelat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequestMovements_ShipmentRequests_ShipmentRequestGUID1",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequestMovements_ShipmentRequestGUID1",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropColumn(
                name: "ShipmentRequestGUID1",
                table: "ShipmentRequestMovements");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestMovements_ShipmentRequestGUID",
                table: "ShipmentRequestMovements",
                column: "ShipmentRequestGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequestMovements_ShipmentRequests_ShipmentRequestGUID",
                table: "ShipmentRequestMovements",
                column: "ShipmentRequestGUID",
                principalTable: "ShipmentRequests",
                principalColumn: "ShipmentRequestGUID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequestMovements_ShipmentRequests_ShipmentRequestGUID",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequestMovements_ShipmentRequestGUID",
                table: "ShipmentRequestMovements");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRequestGUID1",
                table: "ShipmentRequestMovements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestMovements_ShipmentRequestGUID1",
                table: "ShipmentRequestMovements",
                column: "ShipmentRequestGUID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequestMovements_ShipmentRequests_ShipmentRequestGUID1",
                table: "ShipmentRequestMovements",
                column: "ShipmentRequestGUID1",
                principalTable: "ShipmentRequests",
                principalColumn: "ShipmentRequestGUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
