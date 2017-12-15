using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class GroupesAddSouusGroupes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupesId",
                table: "Groupes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_GroupesId",
                table: "Groupes",
                column: "GroupesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groupes_Groupes_GroupesId",
                table: "Groupes",
                column: "GroupesId",
                principalTable: "Groupes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groupes_Groupes_GroupesId",
                table: "Groupes");

            migrationBuilder.DropIndex(
                name: "IX_Groupes_GroupesId",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "GroupesId",
                table: "Groupes");
        }
    }
}
