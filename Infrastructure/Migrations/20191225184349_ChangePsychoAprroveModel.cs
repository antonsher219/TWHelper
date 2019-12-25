using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangePsychoAprroveModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiplomaPath",
                table: "PsychoApproveRequests",
                newName: "TwitterLink");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "PsychoApproveRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DegreeDiplomaFilePath",
                table: "PsychoApproveRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "PsychoApproveRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInLink",
                table: "PsychoApproveRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhDDiplomaFilePath",
                table: "PsychoApproveRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResearchDiplomaFilePath",
                table: "PsychoApproveRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "PsychoApproveRequests");

            migrationBuilder.DropColumn(
                name: "DegreeDiplomaFilePath",
                table: "PsychoApproveRequests");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "PsychoApproveRequests");

            migrationBuilder.DropColumn(
                name: "LinkedInLink",
                table: "PsychoApproveRequests");

            migrationBuilder.DropColumn(
                name: "PhDDiplomaFilePath",
                table: "PsychoApproveRequests");

            migrationBuilder.DropColumn(
                name: "ResearchDiplomaFilePath",
                table: "PsychoApproveRequests");

            migrationBuilder.RenameColumn(
                name: "TwitterLink",
                table: "PsychoApproveRequests",
                newName: "DiplomaPath");
        }
    }
}
