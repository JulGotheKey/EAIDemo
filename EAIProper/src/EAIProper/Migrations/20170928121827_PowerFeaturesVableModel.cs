using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class PowerFeaturesVableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    EquipmentId = table.Column<int>(nullable: false),
                    LongueurCable = table.Column<int>(nullable: false),
                    NombreCable = table.Column<int>(nullable: false),
                    SectionCable = table.Column<int>(nullable: false),
                    TypeCableCommande = table.Column<string>(nullable: true),
                    TypeCableProtection = table.Column<string>(nullable: true),
                    TypeCablePuissance = table.Column<string>(nullable: true),
                    TypeProtection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cables_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    DutyAbsorbedPower = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    InstalledAbsorbedPowerDp = table.Column<int>(nullable: false),
                    MechanicalPowerDemand = table.Column<int>(nullable: false),
                    MotorEfficiency = table.Column<int>(nullable: false),
                    MotorEfficiencyClass = table.Column<string>(nullable: true),
                    NominalInstalledPower = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerFeatures_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cables_EquipmentId",
                table: "Cables",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerFeatures_EquipmentId",
                table: "PowerFeatures",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.DropTable(
                name: "PowerFeatures");
        }
    }
}
