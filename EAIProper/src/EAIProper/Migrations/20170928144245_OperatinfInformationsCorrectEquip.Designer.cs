﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EAIProper.DAL;

namespace EAIProper.Migrations
{
    [DbContext(typeof(EAIContext))]
    [Migration("20170928144245_OperatinfInformationsCorrectEquip")]
    partial class OperatinfInformationsCorrectEquip
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

                    b.Property<int>("EquipmentId");

                    b.Property<string>("File");

                    b.Property<string>("NumeroZone");

                    b.Property<string>("PIDReference");

                    b.Property<string>("SousAtelier");

                    b.Property<string>("ZoneProcess");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("EAIProper.Models.Cables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EquipmentId");

                    b.Property<int>("LongueurCable");

                    b.Property<int>("NombreCable");

                    b.Property<int>("SectionCable");

                    b.Property<string>("TypeCableCommande");

                    b.Property<string>("TypeCableProtection");

                    b.Property<string>("TypeCablePuissance");

                    b.Property<string>("TypeProtection");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Cables");
                });

            modelBuilder.Entity("EAIProper.Models.ElectricalDistributions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlimentationElectrique");

                    b.Property<int>("CosPhi");

                    b.Property<int>("DepartType");

                    b.Property<int>("EquipmentId");

                    b.Property<int>("Intensite");

                    b.Property<string>("MccLocation");

                    b.Property<string>("TgbtLocation");

                    b.Property<string>("Transfo");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("ElectricalDistributions");
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

                    b.Property<int?>("EquipementId");

                    b.Property<int>("EquipmentId");

                    b.Property<string>("Etat");

                    b.Property<bool>("MoteurImerge");

                    b.Property<bool>("Package");

                    b.Property<string>("PackageTypique");

                    b.Property<bool>("Vfd");

                    b.HasKey("Id");

                    b.HasIndex("EquipementId");

                    b.ToTable("OperatingInformations");
                });

            modelBuilder.Entity("EAIProper.Models.PowerFeatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DutyAbsorbedPower");

                    b.Property<int>("EquipmentId");

                    b.Property<int>("InstalledAbsorbedPowerDp");

                    b.Property<int>("MechanicalPowerDemand");

                    b.Property<int>("MotorEfficiency");

                    b.Property<string>("MotorEfficiencyClass");

                    b.Property<int>("NominalInstalledPower");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("PowerFeatures");
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

            modelBuilder.Entity("EAIProper.Models.ThermalDissipations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EquipmentId");

                    b.Property<int>("HVAC");

                    b.Property<int>("HeatDissipation");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("ThermalDissipations");
                });

            modelBuilder.Entity("EAIProper.Models.Areas", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAIProper.Models.Cables", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAIProper.Models.ElectricalDistributions", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .HasForeignKey("EquipementId");
                });

            modelBuilder.Entity("EAIProper.Models.PowerFeatures", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAIProper.Models.ThermalDissipations", b =>
                {
                    b.HasOne("EAIProper.Models.Equipments", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
