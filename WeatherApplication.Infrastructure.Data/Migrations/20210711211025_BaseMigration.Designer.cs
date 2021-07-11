﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApplication.Infrastructure.Data;

namespace WeatherApplication.Infrastructure.Data.Migrations
{
    [DbContext(typeof(WeatherAppContext))]
    [Migration("20210711211025_BaseMigration")]
    partial class BaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApplication.Domain.Core.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfAllowedStatisticalModels")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CityModels");
                });

            modelBuilder.Entity("WeatherApplication.Domain.Core.StatisticalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageRainProbability")
                        .HasColumnType("float");

                    b.Property<double>("AverageTemperature")
                        .HasColumnType("float");

                    b.Property<double>("AverageWindForce")
                        .HasColumnType("float");

                    b.Property<int?>("CityModelId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentRainProbability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentTemperature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentWindForce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateStatisticsCreated")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaxRainProbability")
                        .HasColumnType("float");

                    b.Property<double>("MaxTemperature")
                        .HasColumnType("float");

                    b.Property<double>("MaxWindForce")
                        .HasColumnType("float");

                    b.Property<double>("MinRainProbability")
                        .HasColumnType("float");

                    b.Property<double>("MinTemperature")
                        .HasColumnType("float");

                    b.Property<double>("MinWindForce")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CityModelId");

                    b.ToTable("StatisticalModels");
                });

            modelBuilder.Entity("WeatherApplication.Domain.Core.WeatherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityModelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ObservationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("RainProbability")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("WindForce")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CityModelId");

                    b.ToTable("WeatherModels");
                });

            modelBuilder.Entity("WeatherApplication.Domain.Core.StatisticalModel", b =>
                {
                    b.HasOne("WeatherApplication.Domain.Core.CityModel", "CityModel")
                        .WithMany("Statistics")
                        .HasForeignKey("CityModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeatherApplication.Domain.Core.WeatherModel", b =>
                {
                    b.HasOne("WeatherApplication.Domain.Core.CityModel", "CityModel")
                        .WithMany("WeatherHistory")
                        .HasForeignKey("CityModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}