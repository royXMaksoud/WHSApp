using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablesentrydetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequests_EntryDetails_ShipmentRequestGUID",
                table: "ShipmentRequests");

            migrationBuilder.RenameColumn(
                name: "ShipmentRequestGUID",
                table: "EntryDetails",
                newName: "ShipmentRequestDetailGUID");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDetails_ShipmentRequestDetailGUID",
                table: "EntryDetails",
                column: "ShipmentRequestDetailGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryDetails_ShipmentRequestDetails_ShipmentRequestDetailGUID",
                table: "EntryDetails",
                column: "ShipmentRequestDetailGUID",
                principalTable: "ShipmentRequestDetails",
                principalColumn: "ShipmentRequestDetailGUID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryDetails_ShipmentRequestDetails_ShipmentRequestDetailGUID",
                table: "EntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_EntryDetails_ShipmentRequestDetailGUID",
                table: "EntryDetails");

            migrationBuilder.RenameColumn(
                name: "ShipmentRequestDetailGUID",
                table: "EntryDetails",
                newName: "ShipmentRequestGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequests_EntryDetails_ShipmentRequestGUID",
                table: "ShipmentRequests",
                column: "ShipmentRequestGUID",
                principalTable: "EntryDetails",
                principalColumn: "EntryDetailGUID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
