using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyStoreDL.Migrations
{
    public partial class LatestChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_BeautyProducts_BeautyProductProductId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LocationId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_BeautyProductProductId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BeautyProductProductId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "InventoryTitle",
                table: "Inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoriesId",
                table: "BeautyProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryInventoriesId",
                table: "BeautyProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeautyProducts_InventoryInventoriesId",
                table: "BeautyProducts",
                column: "InventoryInventoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeautyProducts_Inventories_InventoryInventoriesId",
                table: "BeautyProducts",
                column: "InventoryInventoriesId",
                principalTable: "Inventories",
                principalColumn: "InventoriesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeautyProducts_Inventories_InventoryInventoriesId",
                table: "BeautyProducts");

            migrationBuilder.DropIndex(
                name: "IX_BeautyProducts_InventoryInventoriesId",
                table: "BeautyProducts");

            migrationBuilder.DropColumn(
                name: "InventoryTitle",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoriesId",
                table: "BeautyProducts");

            migrationBuilder.DropColumn(
                name: "InventoryInventoriesId",
                table: "BeautyProducts");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeautyProductProductId",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BeautyProductProductId",
                table: "Inventories",
                column: "BeautyProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_BeautyProducts_BeautyProductProductId",
                table: "Inventories",
                column: "BeautyProductProductId",
                principalTable: "BeautyProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
