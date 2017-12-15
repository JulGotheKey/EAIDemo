using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EAIProper.DAL;

namespace EAIProper.Migrations
{
    [DbContext(typeof(EAIContext))]
    [Migration("20170927143636_AutoIncrementProjects")]
    partial class AutoIncrementProjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

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
        }
    }
}
