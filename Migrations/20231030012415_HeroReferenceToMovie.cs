using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaviRazorPageMovieApp.Migrations
{
    public partial class HeroReferenceToMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_HeroId",
                table: "Movies",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_HeroId",
                table: "Movies",
                column: "HeroId",
                principalTable: "Actors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_HeroId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_HeroId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Movies");
        }
    }
}
