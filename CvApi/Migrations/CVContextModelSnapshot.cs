﻿// <auto-generated />
using System;
using CvApi.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CvApi.Migrations
{
    [DbContext(typeof(CVContext))]
    partial class CVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CvApi.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CvApi.Models.Entities.CoverLetter", b =>
                {
                    b.Property<Guid>("CoverLetterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("CoverLetterID");

                    b.HasIndex("UserID");

                    b.ToTable("CoverLetter");
                });

            modelBuilder.Entity("CvApi.Models.Entities.Experience", b =>
                {
                    b.Property<Guid>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ExperienceID");

                    b.HasIndex("UserID");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("CvApi.Models.Entities.JobSkill", b =>
                {
                    b.Property<Guid>("JobSkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Experience")
                        .HasColumnType("double");

                    b.Property<Guid>("JobAdvertisementID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("char(36)");

                    b.HasKey("JobSkillID");

                    b.HasIndex("JobAdvertisementID");

                    b.HasIndex("SkillID");

                    b.ToTable("JobSkill");
                });

            modelBuilder.Entity("CvApi.Models.Entities.ResolvingTables.Application", b =>
                {
                    b.Property<Guid>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CoverLetterID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("JobAdvertisementID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("ApplicationID");

                    b.HasIndex("CoverLetterID");

                    b.HasIndex("JobAdvertisementID");

                    b.HasIndex("UserID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("CvApi.Models.Entities.ResolvingTables.JobAdvertisement", b =>
                {
                    b.Property<Guid>("JobAdvertisementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("CompanyID")
                        .HasColumnType("char(36)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("SalaryFrom")
                        .HasColumnType("double");

                    b.Property<double>("SalaryTo")
                        .HasColumnType("double");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("JobAdvertisementID");

                    b.HasIndex("CompanyID");

                    b.ToTable("JobAdvertisement");
                });

            modelBuilder.Entity("CvApi.Models.Entities.Skill", b =>
                {
                    b.Property<Guid>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SkillID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("CvApi.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CompanyID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID");

                    b.HasIndex("CompanyID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CvApi.Models.Entities.UserSkill", b =>
                {
                    b.Property<Guid>("UserSkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Experience")
                        .HasColumnType("double");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("UserSkillID");

                    b.HasIndex("SkillID");

                    b.HasIndex("UserID");

                    b.ToTable("UserSkill");
                });

            modelBuilder.Entity("CvApi.Models.Entities.CoverLetter", b =>
                {
                    b.HasOne("CvApi.Models.Entities.User", null)
                        .WithMany("CoverLetters")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CvApi.Models.Entities.Experience", b =>
                {
                    b.HasOne("CvApi.Models.Entities.User", null)
                        .WithMany("UserExperiences")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CvApi.Models.Entities.JobSkill", b =>
                {
                    b.HasOne("CvApi.Models.Entities.ResolvingTables.JobAdvertisement", "JobAdvertisement")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobAdvertisementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CvApi.Models.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CvApi.Models.Entities.ResolvingTables.Application", b =>
                {
                    b.HasOne("CvApi.Models.Entities.CoverLetter", "CoverLetter")
                        .WithMany()
                        .HasForeignKey("CoverLetterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CvApi.Models.Entities.ResolvingTables.JobAdvertisement", "JobAdvertisement")
                        .WithMany("Applications")
                        .HasForeignKey("JobAdvertisementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CvApi.Models.Entities.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CvApi.Models.Entities.ResolvingTables.JobAdvertisement", b =>
                {
                    b.HasOne("CvApi.Models.Entities.Company", "Company")
                        .WithMany("JobAdvertisements")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CvApi.Models.Entities.User", b =>
                {
                    b.HasOne("CvApi.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("CvApi.Models.Entities.UserSkill", b =>
                {
                    b.HasOne("CvApi.Models.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CvApi.Models.Entities.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
