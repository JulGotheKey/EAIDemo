using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class CorrectNameEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Equipements_EquipementId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipements_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipementId",
                table: "Areas");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    IdtNumber = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    Revision = table.Column<string>(nullable: true),
                    SuiviAsm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "EquipmentsId",
                table: "Areas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipmentsId",
                table: "Areas",
                column: "EquipmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ProjectId",
                table: "Equipments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Equipments_EquipmentsId",
                table: "Areas",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Equipments_EquipmentsId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatingInformations_Equipments_EquipementId",
                table: "OperatingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Areas_EquipmentsId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "EquipmentsId",
                table: "Areas");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(nullable: true),
                    IdtNumber = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    Revision = table.Column<string>(nullable: true),
                    SuiviAsm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_EquipementId",
                table: "Areas",
                column: "EquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_ProjectId",
                table: "Equipements",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Equipements_EquipementId",
                table: "Areas",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatingInformations_Equipements_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
