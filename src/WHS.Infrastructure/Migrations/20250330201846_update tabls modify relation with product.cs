using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablsmodifyrelationwithproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequestDetails_ProductGUID",
                table: "ShipmentRequestDetails",
                column: "ProductGUID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequestDetails_Products_ProductGUID",
                table: "ShipmentRequestDetails",
                column: "ProductGUID",
                principalTable: "Products",
                principalColumn: "ProductGUID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequestDetails_Products_ProductGUID",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequestDetails_ProductGUID",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");
        }
    }
}
