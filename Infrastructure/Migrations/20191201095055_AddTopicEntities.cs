using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddTopicEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Theme",
                table: "Topics",
                newName: "Header");

            migrationBuilder.RenameColumn(
                name: "CreatingTime",
                table: "Topics",
                newName: "Created");

            migrationBuilder.CreateTable(
                name: "TopicAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<long>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicAnswers_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicAnswers_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicLikes",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    TopicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicLikes", x => new { x.UserId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_TopicLikes_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicAnswers_AuthorId",
                table: "TopicAnswers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicAnswers_TopicId",
                table: "TopicAnswers",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicLikes_TopicId",
                table: "TopicLikes",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicAnswers");

            migrationBuilder.DropTable(
                name: "TopicLikes");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "Topics",
                newName: "Theme");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Topics",
                newName: "CreatingTime");
        }
    }
}
