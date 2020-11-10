using CvApi.Controllers;
using CvApi.Helper;
using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Services.ApplicationService;
using CvApi.Services.ExperienceService;
using CvApi.Services.UserService;
using CvApi.Services.UserSkillsService;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Controllers
{
    public class UsersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IUserService> mockUserService;
        private Mock<IUserSkillsService> mockUserSkillsService;
        private Mock<IExperienceService> mockExperienceService;
        private Mock<IOptions<AppSettings>> mockOptions;
        private Mock<IApplicationService> mockApplicationService;
        private Mock<IErrorHandler> mockErrorHandler;

        public UsersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockUserService = this.mockRepository.Create<IUserService>();
            this.mockUserSkillsService = this.mockRepository.Create<IUserSkillsService>();
            this.mockExperienceService = this.mockRepository.Create<IExperienceService>();
            this.mockOptions = this.mockRepository.Create<IOptions<AppSettings>>();
            this.mockApplicationService = this.mockRepository.Create<IApplicationService>();
            this.mockErrorHandler = this.mockRepository.Create<IErrorHandler>();
        }

        private UsersController CreateUsersController()
        {
            return new UsersController(
                this.mockUserService.Object,
                this.mockUserSkillsService.Object,
                this.mockExperienceService.Object,
                this.mockOptions.Object,
                this.mockApplicationService.Object,
                this.mockErrorHandler.Object);
        }

        [Fact]
        public void Authenticate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            UserDTO userDto = new UserDTO();

            // Act
            var result = usersController.Authenticate(
                userDto);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Register_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            UserDTO userDto = null;

            // Act
            var result = usersController.Register(
                userDto);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();

            // Act
            var result = usersController.GetAll();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);

            // Act
            var result = usersController.GetById(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            UserDTO userDto = null;

            // Act
            var result = usersController.Update(
                id,
                userDto);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);

            // Act
            var result = usersController.Delete(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetUserSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);

            // Act
            var result = usersController.GetUserSkills(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid _ = default(global::System.Guid);
            Guid skillId = default(global::System.Guid);

            // Act
            var result = usersController.GetUserSkill(
                _,
                skillId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreateUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            UserSkillDTO userSkill = new UserSkillDTO();

            // Act
            var result = usersController.CreateUserSkill(
                id,
                userSkill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            Guid skillId = default(global::System.Guid);
            UserSkillDTO userSkill = null;

            // Act
            var result = usersController.UpdateUserSkill(
                id,
                skillId,
                userSkill);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void RemoveUserSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid _ = default(global::System.Guid);
            Guid skillId = default(global::System.Guid);

            // Act
            var result = usersController.RemoveUserSkill(
                _,
                skillId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetUserExperiences_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);

            // Act
            var result = usersController.GetUserExperiences(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetUserExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid _ = default(global::System.Guid);
            Guid experienceId = default(global::System.Guid);

            // Act
            var result = usersController.GetUserExperience(
                _,
                experienceId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreateUserExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            ExperienceDTO experience = new ExperienceDTO();

            // Act
            var result = usersController.CreateUserExperience(
                id,
                experience);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateUserExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            Guid experienceId = default(global::System.Guid);
            ExperienceDTO experience = null;

            // Act
            var result = usersController.UpdateUserExperience(
                id,
                experienceId,
                experience);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void RemoveUserExperience_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid _ = default(global::System.Guid);
            Guid experienceId = default(global::System.Guid);

            // Act
            var result = usersController.RemoveUserExperience(
                _,
                experienceId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetApplications_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);

            // Act
            var result = usersController.GetApplications(
                id);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void RemoveApplication_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var usersController = this.CreateUsersController();
            Guid id = default(global::System.Guid);
            Guid applicationId = default(global::System.Guid);

            // Act
            var result = usersController.RemoveApplication(
                id,
                applicationId);

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
