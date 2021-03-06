﻿// <auto-generated />
using System;
using EDBREOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDBREOS.Migrations
{
    [DbContext(typeof(Contexts))]
    [Migration("20190202183403_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("EDBREOS.Models.Project", b =>
                {
                    b.Property<Guid>("GId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Blocks");

                    b.Property<string>("Commit_ID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DependsOn");

                    b.Property<string>("Description");

                    b.Property<string>("Duplicates");

                    b.Property<string>("Files");

                    b.Property<int>("Id");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Product");

                    b.Property<Guid?>("Project_Id");

                    b.Property<DateTime>("Reported");

                    b.Property<string>("Status");

                    b.Property<string>("Summary");

                    b.Property<string>("Version");

                    b.HasKey("GId");

                    b.HasIndex("Project_Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("EDBREOS.Models.ProjectAdditionalDetails", b =>
                {
                    b.Property<Guid>("GId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<Guid>("ProjectGId");

                    b.Property<Guid?>("Project_Id");

                    b.Property<string>("Value");

                    b.HasKey("GId");

                    b.HasIndex("ProjectGId");

                    b.ToTable("ProjectAD");
                });

            modelBuilder.Entity("EDBREOS.Models.Projects", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EDBREOS.Models.Project", b =>
                {
                    b.HasOne("EDBREOS.Models.Projects", "Projects")
                        .WithMany()
                        .HasForeignKey("Project_Id");
                });

            modelBuilder.Entity("EDBREOS.Models.ProjectAdditionalDetails", b =>
                {
                    b.HasOne("EDBREOS.Models.Project", "Project")
                        .WithMany("ProjectAdditionalDetails")
                        .HasForeignKey("ProjectGId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
