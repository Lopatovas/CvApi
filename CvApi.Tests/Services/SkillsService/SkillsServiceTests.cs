using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Services.SkillsService
{
    public class SkillsServiceTests
    {
        private MockRepository mockRepository;

        private Mock<CVContext> mockCVContext;

        public SkillsServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCVContext = this.mockRepository.Create<CVContext>();
        }

        private CvApi.Services.SkillsService.SkillsService CreateService()
        {
            return new CvApi.Services.SkillsService.SkillsService(
                this.mockCVContext.Object);
        }

        [Fact]
        public void CreateSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Skill skill = null;

            // Act
            service.CreateSkill(
                skill);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            service.DeleteSkill(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetSkillById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = service.GetSkillById(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = service.GetSkills();

            // Assert
            Assert.True(false);
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
            service.UpdateSkill(
                id,
                skill);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
