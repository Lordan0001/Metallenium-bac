using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class Checkkeys7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_BandId",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "albums",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "BandId",
                table: "albums",
                newName: "bandId");

            migrationBuilder.RenameColumn(
                name: "AlbumName",
                table: "albums",
                newName: "albumName");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "albums",
                newName: "albumId");

            migrationBuilder.RenameIndex(
                name: "IX_albums_BandId",
                table: "albums",
                newName: "IX_albums_bandId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_bands_bandId",
                table: "albums",
                column: "bandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_bandId",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "albums",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "bandId",
                table: "albums",
                newName: "BandId");

            migrationBuilder.RenameColumn(
                name: "albumName",
                table: "albums",
                newName: "AlbumName");

            migrationBuilder.RenameColumn(
                name: "albumId",
                table: "albums",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_albums_bandId",
                table: "albums",
                newName: "IX_albums_BandId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_bands_BandId",
                table: "albums",
                column: "BandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
