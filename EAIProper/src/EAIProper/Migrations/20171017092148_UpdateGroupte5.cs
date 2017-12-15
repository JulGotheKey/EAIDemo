using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class UpdateGroupte5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupeId",
                table: "Equipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_GroupeId",
                table: "Equipments",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments",
                column: "GroupeId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Groupes_GroupeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_GroupeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "GroupeId",
                table: "Equipments");
        }
    }
}
