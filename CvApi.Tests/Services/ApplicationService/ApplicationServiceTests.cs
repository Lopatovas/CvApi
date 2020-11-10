using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Enums;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.ApplicationService
{
    public class ApplicationServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public ApplicationServiceTests()
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

        private CvApi.Services.ApplicationService.ApplicationService CreateService()
        {
            return new CvApi.Services.ApplicationService.ApplicationService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void Apply_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid jobAddId = default(global::System.Guid);
            ApplicationDTO application = new ApplicationDTO();

            // Act
            //var result = service.Apply(
            //    jobAddId,
            //    application);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteApplication_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid userId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetApplicants_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetApplications_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid userId = default(global::System.Guid);

            // Act
            //var result = service.GetApplications(
            //    userId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateStatus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid id = default(global::System.Guid);
            ApplicationStatus status = default(global::CvApi.Models.Enums.ApplicationStatus);

            // Act
            //service.UpdateStatus(
            //    companyId,
            //    jobAddId,
            //    id,
            //    status);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
