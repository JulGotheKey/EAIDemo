using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class OperatingInformationsModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperatingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Atex = table.Column<string>(nullable: true),
                    BackupGenset = table.Column<bool>(nullable: false),
                    BackupInverter = table.Column<bool>(nullable: false),
                    EquipementId = table.Column<int>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    MoteurImerge = table.Column<bool>(nullable: false),
                    Package = table.Column<bool>(nullable: false),
                    PackageTypique = table.Column<string>(nullable: true),
                    Vfd = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatingInformations_Equipements_EquipementId",
                        column: x => x.EquipementId,
                        principalTable: "Equipements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatingInformations_EquipementId",
                table: "OperatingInformations",
                column: "EquipementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatingInformations");
        }
    }
}
