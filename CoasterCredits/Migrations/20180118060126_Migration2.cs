using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoasterCredits.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkID",
                table: "Coaster",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Park",
                columns: table => new
                {
                    ParkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParkLatitude = table.Column<float>(nullable: false),
                    ParkLocation = table.Column<string>(nullable: true),
                    ParkLongitude = table.Column<float>(nullable: false),
                    ParkName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Park", x => x.ParkID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaster_ParkID",
                table: "Coaster",
                column: "ParkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaster_Park_ParkID",
                table: "Coaster",
                column: "ParkID",
                principalTable: "Park",
                principalColumn: "ParkID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaster_Park_ParkID",
                table: "Coaster");

            migrationBuilder.DropTable(
                name: "Park");

            migrationBuilder.DropIndex(
                name: "IX_Coaster_ParkID",
                table: "Coaster");

            migrationBuilder.DropColumn(
                name: "ParkID",
                table: "Coaster");
        }
    }
}
