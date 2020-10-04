using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CvApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "JobAdvertisement",
                columns: table => new
                {
                    JobAdvertisementID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 100, nullable: false),
                    SalaryFrom = table.Column<double>(nullable: false),
                    SalaryTo = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EndsAt = table.Column<DateTime>(nullable: false),
                    CompanyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAdvertisement", x => x.JobAdvertisementID);
                    table.ForeignKey(
                        name: "FK_JobAdvertisement_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobSkillID = table.Column<Guid>(nullable: false),
                    Experience = table.Column<double>(nullable: false),
                    SkillID = table.Column<Guid>(nullable: false),
                    JobAdvertisementID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => x.JobSkillID);
                    table.ForeignKey(
                        name: "FK_JobSkill_JobAdvertisement_JobAdvertisementID",
                        column: x => x.JobAdvertisementID,
                        principalTable: "JobAdvertisement",
                        principalColumn: "JobAdvertisementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverLetter",
                columns: table => new
                {
                    CoverLetterID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experience_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    UserSkillID = table.Column<Guid>(nullable: false),
                    Experience = table.Column<double>(nullable: false),
                    SkillID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.UserSkillID);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    JobAdvertisementID = table.Column<Guid>(nullable: false),
                    CoverLetterID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Application_CoverLetter_CoverLetterID",
                        column: x => x.CoverLetterID,
                        principalTable: "CoverLetter",
                        principalColumn: "CoverLetterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_JobAdvertisement_JobAdvertisementID",
                        column: x => x.JobAdvertisementID,
                        principalTable: "JobAdvertisement",
                        principalColumn: "JobAdvertisementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_CoverLetterID",
                table: "Application",
                column: "CoverLetterID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobAdvertisementID",
                table: "Application",
                column: "JobAdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_Application_UserID",
                table: "Application",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CoverLetter_UserID",
                table: "CoverLetter",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserID",
                table: "Experience",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisement_CompanyID",
                table: "JobAdvertisement",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobAdvertisementID",
                table: "JobSkill",
                column: "JobAdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillID",
                table: "JobSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillID",
                table: "UserSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserID",
                table: "UserSkill",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropTable(
                name: "CoverLetter");

            migrationBuilder.DropTable(
                name: "JobAdvertisement");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
