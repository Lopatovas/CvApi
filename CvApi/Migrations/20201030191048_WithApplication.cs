using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CvApi.Migrations
{
    public partial class WithApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_CoverLetter_CoverLetterID",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_CoverLetterID",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CoverLetterID",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Application",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Application");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverLetterID",
                table: "Application",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Application_CoverLetterID",
                table: "Application",
                column: "CoverLetterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_CoverLetter_CoverLetterID",
                table: "Application",
                column: "CoverLetterID",
                principalTable: "CoverLetter",
                principalColumn: "CoverLetterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
