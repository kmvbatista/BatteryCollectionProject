using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CelphoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserPoints");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Discards",
                newName: "Quantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Discards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Discards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discards_PlaceId",
                table: "Discards",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discards_Place_PlaceId",
                table: "Discards",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discards_Place_PlaceId",
                table: "Discards");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Discards_PlaceId",
                table: "Discards");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Discards");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Discards");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Discards",
                newName: "Points");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CelphoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserPoints",
                nullable: false,
                defaultValue: 0);
        }
    }
}
