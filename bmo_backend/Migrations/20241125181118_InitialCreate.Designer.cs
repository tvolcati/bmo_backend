﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bmo_backend.Data;

#nullable disable

namespace bmo_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125181118_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bmo_backend.Models.Distance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float>("DistanceValue")
                        .HasColumnType("real")
                        .HasColumnName("distance");

                    b.Property<long>("Id_running")
                        .HasColumnType("bigint")
                        .HasColumnName("id_running");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Id_running");

                    b.ToTable("Distance");
                });

            modelBuilder.Entity("bmo_backend.Models.Machines", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<float>("MaxTemperature")
                        .HasColumnType("real")
                        .HasColumnName("maxTemperature");

                    b.Property<float>("MaxVibration")
                        .HasColumnType("real")
                        .HasColumnName("maxVibration");

                    b.Property<bool>("NeedFix")
                        .HasColumnType("boolean")
                        .HasColumnName("needFix");

                    b.Property<float>("OilQuality")
                        .HasColumnType("real")
                        .HasColumnName("oil_quality");

                    b.Property<long?>("Type")
                        .HasColumnType("bigint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("bmo_backend.Models.Runnings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("EndTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_timestamp");

                    b.Property<long>("Id_running")
                        .HasColumnType("bigint")
                        .HasColumnName("id_running");

                    b.Property<float>("MeanTemperature")
                        .HasColumnType("real")
                        .HasColumnName("meantemperature");

                    b.Property<float>("MeanVibration")
                        .HasColumnType("real")
                        .HasColumnName("meanvibration");

                    b.Property<DateTime>("StartTimestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_timestamp");

                    b.Property<string>("TypeError")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("typeerror");

                    b.HasKey("Id");

                    b.ToTable("Runnings");
                });

            modelBuilder.Entity("bmo_backend.Models.Temperature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("Id_running")
                        .HasColumnType("bigint")
                        .HasColumnName("id_running");

                    b.Property<float>("TemperatureValue")
                        .HasColumnType("real")
                        .HasColumnName("temperature");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Id_running");

                    b.ToTable("Temperature");
                });

            modelBuilder.Entity("bmo_backend.Models.Vibration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("Id_running")
                        .HasColumnType("bigint")
                        .HasColumnName("id_running");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<float>("VibrationValue")
                        .HasColumnType("real")
                        .HasColumnName("vibration");

                    b.HasKey("Id");

                    b.HasIndex("Id_running");

                    b.ToTable("Vibration");
                });

            modelBuilder.Entity("bmo_backend.Models.Distance", b =>
                {
                    b.HasOne("bmo_backend.Models.Runnings", null)
                        .WithMany()
                        .HasForeignKey("Id_running")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bmo_backend.Models.Temperature", b =>
                {
                    b.HasOne("bmo_backend.Models.Runnings", null)
                        .WithMany()
                        .HasForeignKey("Id_running")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bmo_backend.Models.Vibration", b =>
                {
                    b.HasOne("bmo_backend.Models.Runnings", null)
                        .WithMany()
                        .HasForeignKey("Id_running")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
