using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddPsychologists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPsychologist",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PsychologistProfilePsychologistId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Psychologists",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAccountActivated = table.Column<bool>(nullable: false),
                    AreaOfExpertise = table.Column<string>(nullable: true),
                    WorkExperience = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    HasMasterDegree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.PsychologistId);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PsychologistId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.PsychologistId });
                    table.ForeignKey(
                        name: "FK_Likes_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PsychologistProfilePsychologistId",
                table: "AspNetUsers",
                column: "PsychologistProfilePsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PsychologistId",
                table: "Likes",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId1",
                table: "Likes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Psychologists_PsychologistProfilePsychologistId",
                table: "AspNetUsers",
                column: "PsychologistProfilePsychologistId",
                principalTable: "Psychologists",
                principalColumn: "PsychologistId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Psychologists_PsychologistProfilePsychologistId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Psychologists");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PsychologistProfilePsychologistId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsPsychologist",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PsychologistProfilePsychologistId",
                table: "AspNetUsers");
        }
    }
}
