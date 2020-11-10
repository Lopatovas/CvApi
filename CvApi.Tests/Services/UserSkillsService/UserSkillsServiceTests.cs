using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Services.UserSkillsService
{
    public class UserSkillsServiceTests
    {
        private MockRepository mockRepository;

        private Mock<CVContext> mockCVContext;
        private Mock<IMapper> mockMapper;

        public UserSkillsServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCVContext = this.mockRepository.Create<CVContext>();
            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        private CvApi.Services.UserSkillsService.UserSkillsService CreateService()
        {
            return new CvApi.Services.UserSkillsService.UserSkillsService(
                this.mockCVContext.Object,
                this.mockMapper.Object);
        }

        [Fact]
        public void CreateSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            UserSkillDTO userSkill = null;

            // Act
            service.CreateSkill(
                userSkill);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void DeleteUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            service.DeleteUserSkill(
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
        public void GetUserSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            Guid id = default(global::System.Guid);

            // Act
            var result = service.GetUserSkills(
                id);

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
            UserSkillDTO userSkill = null;

            // Act
            service.UpdateSkill(
                id,
                userSkill);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
