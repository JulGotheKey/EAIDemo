using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAIProper.Migrations
{
    public partial class ElectricalDistributionsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AlimentationElectrique = table.Column<int>(nullable: false),
                    CosPhi = table.Column<int>(nullable: false),
                    DepartType = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<int>(nullable: false),
                    Intensite = table.Column<int>(nullable: false),
                    MccLocation = table.Column<string>(nullable: true),
                    TgbtLocation = table.Column<string>(nullable: true),
                    Transfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricalDistributions_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalDistributions_EquipmentId",
                table: "ElectricalDistributions",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricalDistributions");
        }
    }
}
