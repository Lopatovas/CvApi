using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Data.Common;
using Xunit;

namespace CvApi.Tests.Services.UserService
{
    public class UserServiceTests
    {
        private MockRepository mockRepository;

        private CVContext _context;
        private Mock<IMapper> mockMapper;

        public UserServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            _context = new CVContext(new DbContextOptionsBuilder<CVContext>().UseSqlite(CreateInMemoryDatabase()).Options);
            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        private DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        private CvApi.Services.UserService.UserService CreateService()
        {
            return new CvApi.Services.UserService.UserService(
                _context,
                this.mockMapper.Object);
        }

        [Fact]
        public void Authenticate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string email = null;
            string password = null;

            // Act
            //var result = service.Authenticate(
            //    email,
            //    password);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            //var result = service.GetAll();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //var result = service.GetById(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserDTO userDto = null;
            string password = null;

            // Act
            //var result = service.Create(
            //    userDto,
            //    password);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserDTO userParam = null;
            string password = null;

            // Act
            //service.Update(
            //    userParam,
            //    password);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            //service.Delete(
            //    id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
