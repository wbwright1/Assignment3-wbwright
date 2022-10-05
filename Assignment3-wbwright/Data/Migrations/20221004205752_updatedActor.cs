using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_wbwright.Data.Migrations
{
    public partial class updatedActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Actor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImdbHyperLink",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "ImdbHyperLink",
                table: "Actor");
        }
    }
}
