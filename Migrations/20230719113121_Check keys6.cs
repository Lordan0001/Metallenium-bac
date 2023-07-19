using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class Checkkeys6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_BandsbandId",
                table: "albums");

            migrationBuilder.DropColumn(
                name: "bandNameOfAlbum",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "albums",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "albumName",
                table: "albums",
                newName: "AlbumName");

            migrationBuilder.RenameColumn(
                name: "BandsbandId",
                table: "albums",
                newName: "BandId");

            migrationBuilder.RenameColumn(
                name: "albumuId",
                table: "albums",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_albums_BandsbandId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_BandId",
                table: "albums");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "albums",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "AlbumName",
                table: "albums",
                newName: "albumName");

            migrationBuilder.RenameColumn(
                name: "BandId",
                table: "albums",
                newName: "BandsbandId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "albums",
                newName: "albumuId");

            migrationBuilder.RenameIndex(
                name: "IX_albums_BandId",
                table: "albums",
                newName: "IX_albums_BandsbandId");

            migrationBuilder.AddColumn<string>(
                name: "bandNameOfAlbum",
                table: "albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_bands_BandsbandId",
                table: "albums",
                column: "BandsbandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
