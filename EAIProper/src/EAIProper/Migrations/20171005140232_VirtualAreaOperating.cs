using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class VirtualAreaOperating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations",
                column: "EquipmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas",
                column: "EquipmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas",
                column: "EquipmentId");
        }
    }
}
