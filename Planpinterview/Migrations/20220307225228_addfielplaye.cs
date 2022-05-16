using Microsoft.EntityFrameworkCore.Migrations;

namespace Planpinterview.Migrations
{
    public partial class addfielplaye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "monyvalue",
                table: "players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "monyvalue",
                table: "players");
        }
    }
}
