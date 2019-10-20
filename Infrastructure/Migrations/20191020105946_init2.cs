using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Topics_TopId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TopId",
                table: "Comments",
                newName: "ParentTopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TopId",
                table: "Comments",
                newName: "IX_Comments_ParentTopicId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Topics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Topics_ParentTopicId",
                table: "Comments",
                column: "ParentTopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Topics_ParentTopicId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentTopicId",
                table: "Comments",
                newName: "TopId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentTopicId",
                table: "Comments",
                newName: "IX_Comments_TopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Topics_TopId",
                table: "Comments",
                column: "TopId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
