using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_wbwright.Data.Migrations
{
    public partial class fixedMovieActorLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorPerformedInMovie_Actor_MovieId",
                table: "ActorPerformedInMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPerformedInMovie_Movie_MovieId",
                table: "ActorPerformedInMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorPerformedInMovie_Movie_MovieId",
                table: "ActorPerformedInMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPerformedInMovie_Actor_MovieId",
                table: "ActorPerformedInMovie",
                column: "MovieId",
                principalTable: "Actor",
                principalColumn: "Id");
        }
    }
}
