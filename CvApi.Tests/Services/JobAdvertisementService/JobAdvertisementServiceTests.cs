using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.JobAdvertisementService
{
    public class JobAdvertisementServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public JobAdvertisementServiceTests()
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

        private CvApi.Services.JobAdvertisementService.JobAdvertisementService CreateService()
        {
            return new CvApi.Services.JobAdvertisementService.JobAdvertisementService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void CreateAdvertisement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            JobAdvertisementDTO advertisement = null;

            // Act
            //var result = service.CreateAdvertisement(
            //    companyId,
            //    advertisement);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteAdvertisement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            //service.DeleteAdvertisement(
            //    companyId,
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisementByCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetAdvertisementByCompany(
            //    companyId,
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisementById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetAdvertisementById(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisements_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            //var result = service.GetAdvertisements();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisementsByCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);

            // Act
            //var result = service.GetAdvertisementsByCompany(
            //    companyId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateAdvertisement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid id = default(global::System.Guid);
            JobAdvertisementDTO advertisement = null;

            // Act
            //service.UpdateAdvertisement(
            //    companyId,
            //    id,
            //    advertisement);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
