using CvApi.Controllers;
using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Services.ApplicationService;
using CvApi.Services.JobAdvertisementService;
using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Controllers
{
    public class JobAdvertisementsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IJobAdvertisementService> mockJobAdvertisementService;
        private Mock<IApplicationService> mockApplicationService;
        private Mock<IErrorHandler> mockErrorHandler;

        public JobAdvertisementsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockJobAdvertisementService = this.mockRepository.Create<IJobAdvertisementService>();
            this.mockApplicationService = this.mockRepository.Create<IApplicationService>();
            this.mockErrorHandler = this.mockRepository.Create<IErrorHandler>();
        }

        private JobAdvertisementsController CreateJobAdvertisementsController()
        {
            return new JobAdvertisementsController(
                this.mockJobAdvertisementService.Object,
                this.mockApplicationService.Object,
                this.mockErrorHandler.Object);
        }

        [Fact]
        public void GetAdvertisements_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jobAdvertisementsController = this.CreateJobAdvertisementsController();

            // Act
            var result = jobAdvertisementsController.GetAdvertisements();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetJobAdvertisement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jobAdvertisementsController = this.CreateJobAdvertisementsController();
            Guid id = default(global::System.Guid);

            // Act
            var result = jobAdvertisementsController.GetJobAdvertisement(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Apply_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var jobAdvertisementsController = this.CreateJobAdvertisementsController();
            Guid id = default(global::System.Guid);
            ApplicationDTO application = null;

            // Act
            var result = jobAdvertisementsController.Apply(
                id,
                application);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
