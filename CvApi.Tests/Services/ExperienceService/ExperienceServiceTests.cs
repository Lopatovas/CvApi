using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Services.ExperienceService
{
    public class ExperienceServiceTests
    {
        private MockRepository mockRepository;

        private Mock<CVContext> mockCVContext;
        private Mock<IMapper> mockMapper;

        public ExperienceServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCVContext = this.mockRepository.Create<CVContext>();
            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        private CvApi.Services.ExperienceService.ExperienceService CreateService()
        {
            return new CvApi.Services.ExperienceService.ExperienceService(
                this.mockCVContext.Object,
                this.mockMapper.Object);
        }

        [Fact]
        public void CreateExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            ExperienceDTO experience = null;

            // Act
            service.CreateExperience(
                experience);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            service.DeleteExperience(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = service.GetExperience(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetUserExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = service.GetUserExperience(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);
            ExperienceDTO experience = null;

            // Act
            service.UpdateExperience(
                id,
                experience);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
