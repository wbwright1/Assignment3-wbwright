using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_wbwright.Data.Migrations
{
    public partial class addedMovieActorLinkPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorPerformedInMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPerformedInMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorPerformedInMovie_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActorPerformedInMovie_Actor_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Actor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorPerformedInMovie_ActorId",
                table: "ActorPerformedInMovie",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPerformedInMovie_MovieId",
                table: "ActorPerformedInMovie",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorPerformedInMovie");
        }
    }
}
