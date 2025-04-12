using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablesshipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "Warehouses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "Warehouses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "Suppliers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "Suppliers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCreatorId",
                table: "Suppliers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ShipmentRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ShipmentRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ShipmentRequestMovements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ShipmentRequestMovements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ShipmentRequestMovements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ShipmentRequestDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ShipmentRequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ShipmentRequestDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ShipmentRequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ReleaseRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ReleaseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ReleaseRequestMovements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ReleaseRequestMovements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ReleaseRequestDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ReleaseRequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "ReleaseRequestDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "ReleaseRequestDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdateDate",
                table: "EntryMovements",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "EntryMovements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "EntryDeterminers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "EntryDeterminers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "EntryDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ShipmentDate",
                table: "EntryDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "EntryDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "EntryDetailPrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId",
                table: "EntryDetailPrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElapsedSeconds = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserCreatorId",
                table: "Suppliers",
                column: "UserCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_UserCreatorId",
                table: "Suppliers",
                column: "UserCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_UserCreatorId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_UserCreatorId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UserCreatorId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ShipmentRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ShipmentRequests");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ShipmentRequestMovements");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ShipmentRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ReleaseRequests");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ReleaseRequests");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ReleaseRequestMovements");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ReleaseRequestMovements");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ReleaseRequestDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ReleaseRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ReleaseRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "ReleaseRequestDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "EntryMovements");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "EntryMovements");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EntryDeterminers");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "EntryDeterminers");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "EntryDetails");

            migrationBuilder.DropColumn(
                name: "ShipmentDate",
                table: "EntryDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "EntryDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EntryDetailPrices");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "EntryDetailPrices");
        }
    }
}
