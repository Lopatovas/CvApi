using Moq;
using System;
using Xunit;

namespace CvApi.Tests.Helper.ErrorHandler
{
    public class ErrorHandlerTests
    {
        private MockRepository mockRepository;



        public ErrorHandlerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private CvApi.Helper.ErrorHandler.ErrorHandler CreateErrorHandler()
        {
            return new CvApi.Helper.ErrorHandler.ErrorHandler();
        }

        [Fact]
        public void HandleError_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var errorHandler = this.CreateErrorHandler();
            Exception e = null;

            // Act
            var result = errorHandler.HandleError(
                e);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
