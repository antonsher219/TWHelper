using Microsoft.EntityFrameworkCore.Migrations;

namespace TWHelp.Migrations
{
    public partial class Nicknames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_CreatorId",
                table: "Topics");

            migrationBuilder.AlterColumn<long>(
                name: "CreatorId",
                table: "Topics",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_CreatorId",
                table: "Topics",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_CreatorId",
                table: "Topics");

            migrationBuilder.AlterColumn<long>(
                name: "CreatorId",
                table: "Topics",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_CreatorId",
                table: "Topics",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
