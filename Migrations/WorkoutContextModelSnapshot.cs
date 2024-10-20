﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Models;

#nullable disable

namespace TermProject.Migrations
{
    [DbContext(typeof(WorkoutContext))]
    partial class WorkoutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TermProject.Models.BodyGroup", b =>
                {
                    b.Property<int>("BodyGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BodyGroupId"), 1L, 1);

                    b.Property<string>("BodyGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BodyGroupId");

                    b.ToTable("BodyGroup");

                    b.HasData(
                        new
                        {
                            BodyGroupId = 1,
                            BodyGroupName = "Chest"
                        },
                        new
                        {
                            BodyGroupId = 2,
                            BodyGroupName = "Back"
                        },
                        new
                        {
                            BodyGroupId = 3,
                            BodyGroupName = "Arms"
                        },
                        new
                        {
                            BodyGroupId = 4,
                            BodyGroupName = "Legs"
                        });
                });

            modelBuilder.Entity("TermProject.Models.Workouts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BodyGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BodyGroupId");

                    b.ToTable("Plan");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BodyGroupId = 1,
                            Name = "Barbell Bench Press",
                            Reps = 12,
                            Sets = 4,
                            Weight = 200
                        },
                        new
                        {
                            ID = 2,
                            BodyGroupId = 1,
                            Name = "Dumbbell Fly",
                            Reps = 12,
                            Sets = 4,
                            Weight = 40
                        },
                        new
                        {
                            ID = 3,
                            BodyGroupId = 3,
                            Name = "Skullcrusher",
                            Reps = 12,
                            Sets = 4,
                            Weight = 30
                        });
                });

            modelBuilder.Entity("TermProject.Models.Workouts", b =>
                {
                    b.HasOne("TermProject.Models.BodyGroup", "BodyGroup")
                        .WithMany()
                        .HasForeignKey("BodyGroupId");

                    b.Navigation("BodyGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
