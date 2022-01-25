using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Migrations
{
    public partial class FixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileDescriptions_Mobiles_MobileId",
                table: "MobileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "MobileDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Mobiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufactureDate",
                table: "Mobiles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MobileId",
                table: "MobileDescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileDescriptions_Mobiles_MobileId",
                table: "MobileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Manufacturers_ManufacturerId",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufactureDate",
                table: "Mobiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MobileId",
                table: "MobileDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "MobileDescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileDescriptions_Mobiles_MobileId",
                table: "MobileDescriptions",
                column: "MobileId",
                principalTable: "Mobiles",
                principalColumn: "MobileId",
                onDelete: ReferentialAction.Cascade);

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
