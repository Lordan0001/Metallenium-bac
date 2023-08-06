using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class fixrealeationsissue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_albumId",
                table: "songs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_songs_albumId",
                table: "songs",
                column: "albumId");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs",
                column: "albumId",
                principalTable: "albums",
                principalColumn: "albumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
