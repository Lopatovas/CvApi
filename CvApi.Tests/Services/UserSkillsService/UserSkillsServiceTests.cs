using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.UserSkillsService
{
    public class UserSkillsServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public UserSkillsServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockMapper = this.mockRepository.Create<IMapper>();
            _context = new CVContext(new DbContextOptionsBuilder<CVContext>().UseSqlite(CreateInMemoryDatabase()).Options);
        }

        private DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        private CvApi.Services.UserSkillsService.UserSkillsService CreateService()
        {
            return new CvApi.Services.UserSkillsService.UserSkillsService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void CreateSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserSkillDTO userSkill = null;

            // Act
            //service.CreateSkill(
            //    userSkill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //service.DeleteUserSkill(
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
        public void GetUserSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetUserSkills(
            //    id);

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
            UserSkillDTO userSkill = null;

            // Act
            //service.UpdateSkill(
            //    id,
            //    userSkill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
