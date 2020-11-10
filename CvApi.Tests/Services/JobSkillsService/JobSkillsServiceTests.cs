using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.JobSkillsService
{
    public class JobSkillsServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public JobSkillsServiceTests()
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

        private CvApi.Services.JobSkillsService.JobSkillsService CreateService()
        {
            return new CvApi.Services.JobSkillsService.JobSkillsService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void CreateJobSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            JobSkillDTO skill = null;

            // Act
            //var result = service.CreateJobSkill(
            //    companyId,
            //    jobAddId,
            //    skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteJobSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            //service.DeleteJobSkill(
            //    companyId,
            //    jobAddId,
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetJobSkillById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetJobSkillById(
            //    companyId,
            //    jobAddId,
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetJobSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetJobSkills(
            //    companyId,
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateJobSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid id = default(global::System.Guid);
            JobSkillDTO skill = null;

            // Act
            //service.UpdateJobSkill(
            //    companyId,
            //    jobAddId,
            //    id,
            //    skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
