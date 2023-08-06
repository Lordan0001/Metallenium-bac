using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class testingbandidfield3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_bandId",
                table: "albums");

            migrationBuilder.DropIndex(
                name: "IX_albums_bandId",
                table: "albums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
