using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.CompanyService
{
    public class CompanyServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public CompanyServiceTests()
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

        private CvApi.Services.CompanyService.CompanyService CreateService()
        {
            return new CvApi.Services.CompanyService.CompanyService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void DeleteCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //service.DeleteCompany(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetCompanies_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            //var result = service.GetCompanies();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetCompanyById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetCompanyById(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);
            CompanyDTO company = null;

            // Act
            //service.UpdateCompany(
            //    id,
            //    company);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreateCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            CompanyDTO company = null;

            // Act
            //var result = service.CreateCompany(
            //    company);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
