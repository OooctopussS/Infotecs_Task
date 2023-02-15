﻿// <auto-generated />
using System;
using Infotecs.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infotecs.WebApi.Migrations
{
    [DbContext(typeof(InfotecsDbContext))]
    [Migration("20230213082006_AddAllTimeSecondsToResultsTable")]
    partial class AddAllTimeSecondsToResultsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infotecs.Domain.Result", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AllTimeSeconds")
                        .HasColumnType("int");

                    b.Property<float>("AvgIndicator")
                        .HasColumnType("real");

                    b.Property<int>("AvgSeсonds")
                        .HasColumnType("int");

                    b.Property<int>("CountStrings")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MaxIndicator")
                        .HasColumnType("real");

                    b.Property<float>("MedianIndicator")
                        .HasColumnType("real");

                    b.Property<DateTime>("MinDateAndTime")
                        .HasColumnType("datetime");

                    b.Property<float>("MinIndicator")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Infotecs.Domain.Value", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Indicator")
                        .HasColumnType("real");

                    b.Property<int>("Seсonds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
