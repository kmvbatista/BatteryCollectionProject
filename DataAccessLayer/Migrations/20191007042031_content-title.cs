using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class contenttitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ask",
                table: "AskAndAnswers",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "AskAndAnswers",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "AskAndAnswers",
                newName: "Ask");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "AskAndAnswers",
                newName: "Answer");
        }
    }
}
