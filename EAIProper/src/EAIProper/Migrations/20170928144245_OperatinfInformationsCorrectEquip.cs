using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class OperatinfInformationsCorrectEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "OperatingInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EquipementId",
                table: "OperatingInformations",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "OperatingInformations");

            migrationBuilder.AlterColumn<int>(
                name: "EquipementId",
                table: "OperatingInformations",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
