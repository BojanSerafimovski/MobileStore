using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Migrations
{
    public partial class MobileDescriptionForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileDescriptions_Mobiles_MobileId",
                table: "MobileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_MobileDescriptions_MobileId",
                table: "MobileDescriptions");

            migrationBuilder.DropColumn(
                name: "MobileId",
                table: "MobileDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Mobiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MobileDescriptionId",
                table: "Mobiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_MobileDescriptionId",
                table: "Mobiles",
                column: "MobileDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
                table: "Mobiles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_MobileDescriptions_MobileDescriptionId",
                table: "Mobiles",
                column: "MobileDescriptionId",
                principalTable: "MobileDescriptions",
                principalColumn: "MobileDescriptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
                table: "Mobiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_MobileDescriptions_MobileDescriptionId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_MobileDescriptionId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "MobileDescriptionId",
                table: "Mobiles");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Mobiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MobileId",
                table: "MobileDescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobileDescriptions_MobileId",
                table: "MobileDescriptions",
                column: "MobileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileDescriptions_Mobiles_MobileId",
                table: "MobileDescriptions",
                column: "MobileId",
                principalTable: "Mobiles",
                principalColumn: "MobileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
                table: "Mobiles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
