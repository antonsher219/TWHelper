using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddStoringAnalyzedTweets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwitterUserTweets",
                columns: table => new
                {
                    TwitterNick = table.Column<string>(nullable: false),
                    Tweet = table.Column<string>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterUserTweets", x => x.TwitterNick);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwitterUserTweets");
        }
    }
}
