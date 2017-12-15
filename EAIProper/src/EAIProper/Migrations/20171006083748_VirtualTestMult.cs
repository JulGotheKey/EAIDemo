using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class VirtualTestMult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThermalDissipations_EquipmentId",
                table: "ThermalDissipations");

            migrationBuilder.DropIndex(
                name: "IX_PowerFeatures_EquipmentId",
                table: "PowerFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalDistributions_EquipmentId",
                table: "ElectricalDistributions");

            migrationBuilder.DropIndex(
                name: "IX_Cables_EquipmentId",
                table: "Cables");

            migrationBuilder.CreateIndex(
                name: "IX_ThermalDissipations_EquipmentId",
                table: "ThermalDissipations",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerFeatures_EquipmentId",
                table: "PowerFeatures",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalDistributions_EquipmentId",
                table: "ElectricalDistributions",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cables_EquipmentId",
                table: "Cables",
                column: "EquipmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThermalDissipations_EquipmentId",
                table: "ThermalDissipations");

            migrationBuilder.DropIndex(
                name: "IX_PowerFeatures_EquipmentId",
                table: "PowerFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalDistributions_EquipmentId",
                table: "ElectricalDistributions");

            migrationBuilder.DropIndex(
                name: "IX_Cables_EquipmentId",
                table: "Cables");

            migrationBuilder.CreateIndex(
                name: "IX_ThermalDissipations_EquipmentId",
                table: "ThermalDissipations",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerFeatures_EquipmentId",
                table: "PowerFeatures",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalDistributions_EquipmentId",
                table: "ElectricalDistributions",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_EquipmentId",
                table: "Cables",
                column: "EquipmentId");
        }
    }
}
