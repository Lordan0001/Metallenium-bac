using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metall_Fest.Migrations
{
    /// <inheritdoc />
    public partial class Checkkeys3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandsbandId",
                table: "albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_albums_BandsbandId",
                table: "albums",
                column: "BandsbandId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_bands_BandsbandId",
                table: "albums",
                column: "BandsbandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_bands_BandsbandId",
                table: "albums");

            migrationBuilder.DropIndex(
                name: "IX_albums_BandsbandId",
                table: "albums");

            migrationBuilder.DropColumn(
                name: "BandsbandId",
                table: "albums");
        }
    }
}
