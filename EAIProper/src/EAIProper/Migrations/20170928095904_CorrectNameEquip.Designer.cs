using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EAIProper.DAL;

namespace EAIProper.Migrations
{
    [DbContext(typeof(EAIContext))]
    [Migration("20170928095904_CorrectNameEquip")]
    partial class CorrectNameEquip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("EAIProper.Models.Areas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Atelier");

                    b.Property<int>("EquipementId");

                    b.Property<int?>("EquipmentsId");

                    b.Property<string>("File");

                    b.Property<string>("NumeroZone");

                    b.Property<string>("PIDReference");

                    b.Property<string>("SousAtelier");

                    b.Property<string>("ZoneProcess");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentsId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("EAIProper.Models.Equipments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("IdtNumber");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Revision");

                    b.Property<string>("SuiviAsm");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("EAIProper.Models.OperatingInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Atex");

                    b.Property<bool>("BackupGenset");

                    b.Property<bool>("BackupInverter");

                    b.Property<int>("EquipementId");

                    b.Property<string>("Etat");

                    b.Property<bool>("MoteurImerge");

                    b.Property<bool>("Package");

                    b.Property<string>("PackageTypique");

                    b.Property<bool>("Vfd");

                    b.HasKey("Id");

                    b.HasIndex("EquipementId");

                    b.ToTable("OperatingInformations");
                });

            modelBuilder.Entity("EAIProper.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EAIProper.Models.Areas", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipments")
                        .WithMany()
                        .HasForeignKey("EquipmentsId");
                });

            modelBuilder.Entity("EAIProper.Models.Equipments", b =>
                {
                    b.HasOne("EAIProper.Models.Projects", "Project")
                        .WithMany("Equipments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAIProper.Models.OperatingInformations", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipement")
                        .WithMany()
                        .HasForeignKey("EquipementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
