using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Championship.DAL.Migrations
{
    public partial class NewColumnsInTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsConceded",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsScored",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalsConceded",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsScored",
                table: "Teams");
        }
    }
}
