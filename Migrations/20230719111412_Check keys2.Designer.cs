﻿// <auto-generated />
using System;
using Metall_Fest.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Metall_Fest.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20230719111412_Check keys2")]
    partial class Checkkeys2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Metall_Fest.models.Album", b =>
                {
                    b.Property<int>("albumuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("albumuId"));

                    b.Property<string>("albumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bandNameOfAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("albumuId");

                    b.ToTable("albums");
                });

            modelBuilder.Entity("Metall_Fest.models.Band", b =>
                {
                    b.Property<int>("bandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bandId"));

                    b.Property<string>("bandDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bandType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bandId");

                    b.ToTable("bands");
                });
#pragma warning restore 612, 618
        }
    }
}