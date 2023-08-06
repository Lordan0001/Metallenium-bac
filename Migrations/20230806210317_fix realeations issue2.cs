﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class fixrealeationsissue2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "bands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_songs_albumId",
                table: "songs",
                column: "albumId");

            migrationBuilder.CreateIndex(
                name: "IX_albums_bandId",
                table: "albums",
                column: "bandId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_bands_bandId",
                table: "albums",
                column: "bandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs",
                column: "albumId",
                principalTable: "albums",
                principalColumn: "albumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_bandId",
                table: "albums");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_albumId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_albums_bandId",
                table: "albums");

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "bands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
