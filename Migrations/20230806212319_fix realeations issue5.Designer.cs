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
    [Migration("20230806212319_fix realeations issue5")]
    partial class fixrealeationsissue5
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
                    b.Property<int>("albumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("albumId"));

                    b.Property<string>("albumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("releaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("albumId");

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

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bandId");

                    b.ToTable("bands");
                });

            modelBuilder.Entity("Metall_Fest.models.Song", b =>
                {
                    b.Property<int>("songId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("songId"));

                    b.Property<int>("albumId")
                        .HasColumnType("int");

                    b.Property<string>("songTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("songId");

                    b.ToTable("songs");
                });
#pragma warning restore 612, 618
        }
    }
}
