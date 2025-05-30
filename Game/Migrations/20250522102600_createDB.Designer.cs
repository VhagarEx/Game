﻿// <auto-generated />
using System;
using Game.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20250522102600_createDB")]
    partial class createDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GamerId")
                        .HasColumnType("int");

                    b.Property<int?>("Gamer_ID")
                        .HasColumnType("int");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<int?>("Level_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GamerId");

                    b.HasIndex("LevelId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Gamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRegistr")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Paswd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gamer");
                });

            modelBuilder.Entity("Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Character", b =>
                {
                    b.HasOne("Gamer", "Gamer")
                        .WithMany("Characters")
                        .HasForeignKey("GamerId");

                    b.HasOne("Level", "Level")
                        .WithMany("Characters")
                        .HasForeignKey("LevelId");

                    b.Navigation("Gamer");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Gamer", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Level", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
