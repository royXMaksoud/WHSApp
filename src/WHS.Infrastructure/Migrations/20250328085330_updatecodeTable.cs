using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatecodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerId",
                table: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Warehouses",
                newName: "OwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses",
                newName: "IX_Warehouses_OwnerUserId");

            migrationBuilder.CreateTable(
                name: "CodeTable",
                columns: table => new
                {
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTable", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "CodeTableValue",
                columns: table => new
                {
                    TableValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeTableValue", x => x.TableValueId);
                    table.ForeignKey(
                        name: "FK_CodeTableValue_CodeTable_TableId",
                        column: x => x.TableId,
                        principalTable: "CodeTable",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeTableValue_TableId",
                table: "CodeTableValue",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerUserId",
                table: "Warehouses",
                column: "OwnerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerUserId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "CodeTableValue");

            migrationBuilder.DropTable(
                name: "CodeTable");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Warehouses",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_OwnerUserId",
                table: "Warehouses",
                newName: "IX_Warehouses_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerId",
                table: "Warehouses",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
