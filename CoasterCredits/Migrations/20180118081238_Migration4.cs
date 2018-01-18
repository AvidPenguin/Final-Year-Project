using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoasterCredits.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaster_Manufacturer_CoasterManufacturerManufacturerID",
                table: "Coaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Coaster_Park_CoasterParkParkID",
                table: "Coaster");

            migrationBuilder.DropIndex(
                name: "IX_Coaster_CoasterManufacturerManufacturerID",
                table: "Coaster");

            migrationBuilder.DropIndex(
                name: "IX_Coaster_CoasterParkParkID",
                table: "Coaster");

            migrationBuilder.DropColumn(
                name: "CoasterManufacturerManufacturerID",
                table: "Coaster");

            migrationBuilder.DropColumn(
                name: "CoasterParkParkID",
                table: "Coaster");

            migrationBuilder.AddColumn<string>(
                name: "CoasterManufacturer",
                table: "Coaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoasterPark",
                table: "Coaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoasterManufacturer",
                table: "Coaster");

            migrationBuilder.DropColumn(
                name: "CoasterPark",
                table: "Coaster");

            migrationBuilder.AddColumn<int>(
                name: "CoasterManufacturerManufacturerID",
                table: "Coaster",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoasterParkParkID",
                table: "Coaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaster_CoasterManufacturerManufacturerID",
                table: "Coaster",
                column: "CoasterManufacturerManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Coaster_CoasterParkParkID",
                table: "Coaster",
                column: "CoasterParkParkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaster_Manufacturer_CoasterManufacturerManufacturerID",
                table: "Coaster",
                column: "CoasterManufacturerManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coaster_Park_CoasterParkParkID",
                table: "Coaster",
                column: "CoasterParkParkID",
                principalTable: "Park",
                principalColumn: "ParkID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
