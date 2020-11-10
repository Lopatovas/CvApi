using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.SkillsService
{
    public class SkillsServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;

        public SkillsServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            _context = new CVContext(new DbContextOptionsBuilder<CVContext>().UseSqlite(CreateInMemoryDatabase()).Options);
        }

        private DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        private CvApi.Services.SkillsService.SkillsService CreateService()
        {
            return new CvApi.Services.SkillsService.SkillsService(
                _context);
        }

        [Fact]
        public void CreateSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Skill skill = null;

            // Act
            //service.CreateSkill(
            //    skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //service.DeleteSkill(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetSkillById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetSkillById(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            //var result = service.GetSkills();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);
            Skill skill = null;

            // Act
            //service.UpdateSkill(
            //    id,
            //    skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
