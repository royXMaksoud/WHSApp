using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WHS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class warehouseOwnerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Warehouses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("UPDATE Warehouses Set OwnerID=(select TOp 1 Id from AspNetUsers)");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerId",
                table: "Warehouses",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Warehouses");
        }
    }
}