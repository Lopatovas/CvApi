using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CvApi.Migrations
{
    public partial class Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverLetter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverLetter",
                columns: table => new
                {
                    CoverLetterID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverLetter", x => x.CoverLetterID);
                    table.ForeignKey(
                        name: "FK_CoverLetter_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverLetter_UserID",
                table: "CoverLetter",
                column: "UserID");
        }
    }
}
