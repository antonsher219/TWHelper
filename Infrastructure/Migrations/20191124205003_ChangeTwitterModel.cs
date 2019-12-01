using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeTwitterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadEmotionRate",
                table: "TwitterUserStatistics");

            migrationBuilder.DropColumn(
                name: "GoodEmotionRate",
                table: "TwitterUserStatistics");

            migrationBuilder.AddColumn<string>(
                name: "TopNegativeWordsJson",
                table: "TwitterUserStatistics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopPositiveWordsJson",
                table: "TwitterUserStatistics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopNegativeWordsJson",
                table: "TwitterUserStatistics");

            migrationBuilder.DropColumn(
                name: "TopPositiveWordsJson",
                table: "TwitterUserStatistics");

            migrationBuilder.AddColumn<double>(
                name: "BadEmotionRate",
                table: "TwitterUserStatistics",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GoodEmotionRate",
                table: "TwitterUserStatistics",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
