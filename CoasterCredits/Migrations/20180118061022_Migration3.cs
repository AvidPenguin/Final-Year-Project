using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoasterCredits.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaster_Park_ParkID",
                table: "Coaster");

            migrationBuilder.RenameColumn(
                name: "ParkID",
                table: "Coaster",
                newName: "CoasterParkParkID");

            migrationBuilder.RenameIndex(
                name: "IX_Coaster_ParkID",
                table: "Coaster",
                newName: "IX_Coaster_CoasterParkParkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaster_Park_CoasterParkParkID",
                table: "Coaster",
                column: "CoasterParkParkID",
                principalTable: "Park",
                principalColumn: "ParkID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaster_Park_CoasterParkParkID",
                table: "Coaster");

            migrationBuilder.RenameColumn(
                name: "CoasterParkParkID",
                table: "Coaster",
                newName: "ParkID");

            migrationBuilder.RenameIndex(
                name: "IX_Coaster_CoasterParkParkID",
                table: "Coaster",
                newName: "IX_Coaster_ParkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaster_Park_ParkID",
                table: "Coaster",
                column: "ParkID",
                principalTable: "Park",
                principalColumn: "ParkID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
