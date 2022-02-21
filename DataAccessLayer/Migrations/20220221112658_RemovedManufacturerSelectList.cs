using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Migrations
{
    public partial class RemovedManufacturerSelectList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Mobiles_MobileId1",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_MobileId1",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "MobileId1",
                table: "Mobiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MobileId1",
                table: "Mobiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_MobileId1",
                table: "Mobiles",
                column: "MobileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Mobiles_MobileId1",
                table: "Mobiles",
                column: "MobileId1",
                principalTable: "Mobiles",
                principalColumn: "MobileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
