using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablsmodifyrelationwithdutystaionsupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequests_Suppliers_SupplierGUID1",
                table: "ShipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequests_SupplierGUID1",
                table: "ShipmentRequests");

            migrationBuilder.DropColumn(
                name: "SupplierGUID1",
                table: "ShipmentRequests");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_SupplierGUID",
                table: "ShipmentRequests",
                column: "SupplierGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequests_Suppliers_SupplierGUID",
                table: "ShipmentRequests",
                column: "SupplierGUID",
                principalTable: "Suppliers",
                principalColumn: "SupplierGUID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequests_Suppliers_SupplierGUID",
                table: "ShipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequests_SupplierGUID",
                table: "ShipmentRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierGUID1",
                table: "ShipmentRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_SupplierGUID1",
                table: "ShipmentRequests",
                column: "SupplierGUID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequests_Suppliers_SupplierGUID1",
                table: "ShipmentRequests",
                column: "SupplierGUID1",
                principalTable: "Suppliers",
                principalColumn: "SupplierGUID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
