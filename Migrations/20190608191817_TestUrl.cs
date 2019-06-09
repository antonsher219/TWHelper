using Microsoft.EntityFrameworkCore.Migrations;

namespace TWHelp.Migrations
{
    public partial class TestUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestUrl",
                table: "Tests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestUrl",
                table: "Tests");
        }
    }
}
