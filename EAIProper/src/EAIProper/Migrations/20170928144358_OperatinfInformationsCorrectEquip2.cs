using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class OperatinfInformationsCorrectEquip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_OperatingInformations_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.DropColumn(
                name: "EquipementId",
                table: "OperatingInformations");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipmentId",
                table: "OperatingInformations",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipmentId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_OperatingInformations_EquipmentId",
                table: "OperatingInformations");

            migrationBuilder.AddColumn<int>(
                name: "EquipementId",
                table: "OperatingInformations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatingInformations_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
