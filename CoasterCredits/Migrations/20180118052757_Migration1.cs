using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoasterCredits.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaster",
                columns: table => new
                {
                    CoasterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoasterHeight = table.Column<float>(nullable: false),
                    CoasterInversions = table.Column<int>(nullable: false),
                    CoasterLength = table.Column<float>(nullable: false),
                    CoasterManufacturerManufacturerID = table.Column<int>(nullable: true),
                    CoasterName = table.Column<string>(nullable: true),
                    CoasterSpeed = table.Column<float>(nullable: false),
                    CoasterStatus = table.Column<int>(nullable: false),
                    CoasterStyle = table.Column<int>(nullable: false),
                    CoasterType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaster", x => x.CoasterID);
                    table.ForeignKey(
                        name: "FK_Coaster_Manufacturer_CoasterManufacturerManufacturerID",
                        column: x => x.CoasterManufacturerManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coaster_CoasterManufacturerManufacturerID",
                table: "Coaster",
                column: "CoasterManufacturerManufacturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaster");
        }
    }
}
