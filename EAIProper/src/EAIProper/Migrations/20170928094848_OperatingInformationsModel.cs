using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class OperatingInformationsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Projects_ProjectId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ProjectId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "EquipementId",
                table: "Areas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipementId",
                table: "Areas",
                column: "EquipementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Equipements_EquipementId",
                table: "Areas",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Equipements_EquipementId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipementId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipementId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Areas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ProjectId",
                table: "Areas",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Projects_ProjectId",
                table: "Areas",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
