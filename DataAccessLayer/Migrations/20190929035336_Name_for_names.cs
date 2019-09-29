using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Name_for_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "Discards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Discards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Discards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "Discards");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Discards");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Discards");
        }
    }
}
