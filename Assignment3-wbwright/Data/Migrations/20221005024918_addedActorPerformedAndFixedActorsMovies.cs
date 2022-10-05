using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_wbwright.Data.Migrations
{
    public partial class addedActorPerformedAndFixedActorsMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Actor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ActorId",
                table: "Movie",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_MovieId",
                table: "Actor",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Actor_MovieId",
                table: "Actor",
                column: "MovieId",
                principalTable: "Actor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Actor_MovieId",
                table: "Actor");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ActorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Actor_MovieId",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actor");
        }
    }
}
