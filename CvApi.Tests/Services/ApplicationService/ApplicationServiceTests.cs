using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Enums;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Services.ApplicationService
{
    public class ApplicationServiceTests
    {
        private MockRepository mockRepository;

        private Mock<CVContext> mockCVContext;
        private Mock<IMapper> mockMapper;

        public ApplicationServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCVContext = this.mockRepository.Create<CVContext>();
            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        private CvApi.Services.ApplicationService.ApplicationService CreateService()
        {
            return new CvApi.Services.ApplicationService.ApplicationService(
                this.mockCVContext.Object,
                this.mockMapper.Object);
        }

        [Fact]
        public void Apply_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid jobAddId = default(global::System.Guid);
            ApplicationDTO application = null;

            // Act
            var result = service.Apply(
                jobAddId,
                application);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteApplication_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid userId = default(global::System.Guid);
            Guid id = default(global::System.Guid);

            // Act
            service.DeleteApplication(
                userId,
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetApplicants_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid companyId = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);

            // Act
            var result = service.GetApplicants(
                companyId,
                jobAddId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetApplications_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid userId = default(global::System.Guid);

            // Act
            var result = service.GetApplications(
                userId);

            // Assert
            Assert.True(false);
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
            service.UpdateStatus(
                companyId,
                jobAddId,
                id,
                status);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
