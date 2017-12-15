using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class CorrectAreaForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Equipments_EquipmentsId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipmentsId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipementId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipmentsId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Areas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Equipments_EquipmentId",
                table: "Areas",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Equipments_EquipmentId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipmentId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "EquipementId",
                table: "Areas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentsId",
                table: "Areas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipmentsId",
                table: "Areas",
                column: "EquipmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Equipments_EquipmentsId",
                table: "Areas",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
