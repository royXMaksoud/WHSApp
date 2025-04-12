using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetablsuseraccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseRequestMovements_AspNetUsers_UsersId",
                table: "ReleaseRequestMovements");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ReleaseRequestMovements",
                newName: "UserCreatorId");

            migrationBuilder.RenameColumn(
                name: "CreateById",
                table: "ReleaseRequestMovements",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReleaseRequestMovements_UsersId",
                table: "ReleaseRequestMovements",
                newName: "IX_ReleaseRequestMovements_UserCreatorId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ShipmentRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ShipmentRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ReleaseRequests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "ReleaseRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserCreatorId",
                table: "ReleaseRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "ReleaseRequestMovements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "EntryMovements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateDate",
                table: "EntryDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "EntryDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_CreatedByUserId",
                table: "ShipmentRequests",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseRequests_UserCreatorId",
                table: "ReleaseRequests",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDetails_CreatedByUserId",
                table: "EntryDetails",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryDetails_AspNetUsers_CreatedByUserId",
                table: "EntryDetails",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseRequestMovements_AspNetUsers_UserCreatorId",
                table: "ReleaseRequestMovements",
                column: "UserCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseRequests_AspNetUsers_UserCreatorId",
                table: "ReleaseRequests",
                column: "UserCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentRequests_AspNetUsers_CreatedByUserId",
                table: "ShipmentRequests",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryDetails_AspNetUsers_CreatedByUserId",
                table: "EntryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseRequestMovements_AspNetUsers_UserCreatorId",
                table: "ReleaseRequestMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseRequests_AspNetUsers_UserCreatorId",
                table: "ReleaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentRequests_AspNetUsers_CreatedByUserId",
                table: "ShipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentRequests_CreatedByUserId",
                table: "ShipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseRequests_UserCreatorId",
                table: "ReleaseRequests");

            migrationBuilder.DropIndex(
                name: "IX_EntryDetails_CreatedByUserId",
                table: "EntryDetails");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ShipmentRequests");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ShipmentRequests");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ReleaseRequests");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ReleaseRequests");

            migrationBuilder.DropColumn(
                name: "UserCreatorId",
                table: "ReleaseRequests");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ReleaseRequestMovements");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "EntryMovements");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "EntryDetails");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "EntryDetails");

            migrationBuilder.RenameColumn(
                name: "UserCreatorId",
                table: "ReleaseRequestMovements",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "ReleaseRequestMovements",
                newName: "CreateById");

            migrationBuilder.RenameIndex(
                name: "IX_ReleaseRequestMovements_UserCreatorId",
                table: "ReleaseRequestMovements",
                newName: "IX_ReleaseRequestMovements_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseRequestMovements_AspNetUsers_UsersId",
                table: "ReleaseRequestMovements",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
