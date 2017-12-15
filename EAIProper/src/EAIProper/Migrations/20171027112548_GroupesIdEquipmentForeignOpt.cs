using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class GroupesIdEquipmentForeignOpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments");

            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Equipments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments",
                column: "GroupeId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments");

            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Equipments",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments",
                column: "GroupeId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
