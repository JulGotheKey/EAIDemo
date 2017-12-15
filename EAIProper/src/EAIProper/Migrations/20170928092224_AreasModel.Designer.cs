using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EAIProper.DAL;

namespace EAIProper.Migrations
{
    [DbContext(typeof(EAIContext))]
    [Migration("20170928092224_AreasModel")]
    partial class AreasModel
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

                    b.Property<string>("File");

                    b.Property<string>("NumeroZone");

                    b.Property<string>("PIDReference");

                    b.Property<int>("ProjectId");

                    b.Property<string>("SousAtelier");

                    b.Property<string>("ZoneProcess");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("EAIProper.Models.Equipements", b =>
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

                    b.ToTable("Equipements");
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
                    b.HasOne("EAIProper.Models.Projects", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EAIProper.Models.Equipements", b =>
                {
                    b.HasOne("EAIProper.Models.Projects", "Project")
                        .WithMany("Equipements")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
