using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Services.JobAdvertisementService
{
    public class JobAdvertisementServiceTests
    {
        private MockRepository mockRepository;

        private Mock<CVContext> mockCVContext;
        private Mock<IMapper> mockMapper;

        public JobAdvertisementServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCVContext = this.mockRepository.Create<CVContext>();
            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        private CvApi.Services.JobAdvertisementService.JobAdvertisementService CreateService()
        {
            return new CvApi.Services.JobAdvertisementService.JobAdvertisementService(
                this.mockCVContext.Object,
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
            var result = service.CreateAdvertisement(
                companyId,
                advertisement);

            // Assert
            Assert.True(false);
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
            service.DeleteAdvertisement(
                companyId,
                id);

            // Assert
            Assert.True(false);
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
            var result = service.GetAdvertisementByCompany(
                companyId,
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisementById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = service.GetAdvertisementById(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisements_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetAdvertisements();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAdvertisementsByCompany_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);

            // Act
            var result = service.GetAdvertisementsByCompany(
                companyId);

            // Assert
            Assert.True(false);
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
            service.UpdateAdvertisement(
                companyId,
                id,
                advertisement);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
