using CvApi.Controllers;
using CvApi.Models.Entities;
using CvApi.Services.SkillsService;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Controllers
{
    public class SkillsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ISkillsService> mockSkillsService;

        public SkillsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockSkillsService = this.mockRepository.Create<ISkillsService>();
        }

        private SkillsController CreateSkillsController()
        {
            return new SkillsController(
                this.mockSkillsService.Object);
        }

        [Fact]
        public void GetSkillEntities_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            // Act
            var result = skillsController.GetSkillEntities();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            Guid id = default(global::System.Guid);

            // Act
            var result = skillsController.GetSkill(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void PutSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            Guid id = default(global::System.Guid);
            Skill skill = null;

            // Act
            var result = skillsController.PutSkill(
                id,
                skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void PostSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            Skill skill = new Skill();

            // Act
            var result = skillsController.PostSkill(
                skill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            Guid id = default(global::System.Guid);

            // Act
            var result = skillsController.DeleteSkill(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
