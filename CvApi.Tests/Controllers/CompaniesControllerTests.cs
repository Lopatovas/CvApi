using CvApi.Controllers;
using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Enums;
using CvApi.Services.ApplicationService;
using CvApi.Services.CompanyService;
using CvApi.Services.JobAdvertisementService;
using CvApi.Services.JobSkillsService;
using CvApi.Tests.Controllers.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CvApi.Tests.Controllers
{
    public class CompaniesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ICompanyService> mockCompanyService;
        private Mock<IJobSkillsService> mockJobSkillsService;
        private Mock<IJobAdvertisementService> mockJobAdvertisementService;
        private Mock<IErrorHandler> mockErrorHandler;
        private Mock<IApplicationService> mockApplicationService;

        public CompaniesControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockCompanyService = this.mockRepository.Create<ICompanyService>();
            this.mockJobSkillsService = this.mockRepository.Create<IJobSkillsService>();
            this.mockJobAdvertisementService = this.mockRepository.Create<IJobAdvertisementService>();
            this.mockErrorHandler = this.mockRepository.Create<IErrorHandler>();
            this.mockApplicationService = this.mockRepository.Create<IApplicationService>();
        }

        private CompaniesController CreateCompaniesController()
        {
            return new CompaniesController(
                this.mockCompanyService.Object,
                this.mockJobSkillsService.Object,
                this.mockJobAdvertisementService.Object,
                this.mockErrorHandler.Object,
                this.mockApplicationService.Object);
        }

        private void MockCompanyService(List<CompanyDTO> companies)
        {
            mockCompanyService.Setup(m => m.GetCompanies()).Returns(companies);
            mockCompanyService.Setup(m => m.GetCompanyById(It.IsAny<Guid>())).Returns(companies[0]);
            mockCompanyService.Setup(m => m.UpdateCompany(It.IsAny<Guid>(), It.IsAny<CompanyDTO>()));
            mockCompanyService.Setup(m => m.CreateCompany(It.IsAny<CompanyDTO>())).Returns<CompanyDTO>(newCompany => newCompany);
            mockCompanyService.Setup(m => m.DeleteCompany(It.IsAny<Guid>()));
        }

        private void MockJobAdvertisementService(List<JobAdvertisementDTO> jobAdds)
        {
            mockJobAdvertisementService.Setup(m => m.GetAdvertisementsByCompany(It.IsAny<Guid>())).Returns(jobAdds);
            mockJobAdvertisementService.Setup(m => m.GetAdvertisementByCompany(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(jobAdds[0]);
            mockJobAdvertisementService.Setup(m => m.UpdateAdvertisement(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<JobAdvertisementDTO>()));
            mockJobAdvertisementService.Setup(m => m.CreateAdvertisement(It.IsAny<Guid>(), It.IsAny<JobAdvertisementDTO>())).Returns<Guid, JobAdvertisementDTO>((id, m) => m);
            mockJobAdvertisementService.Setup(m => m.DeleteAdvertisement(It.IsAny<Guid>(), It.IsAny<Guid>()));
        }

        [Fact]
        public void GetCompanyEntities_Default_ShouldReturnListOfCompanies()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            MockCompanyService(new List<CompanyDTO> { new CompanyDTO { Title = "Title 1" } });

            // Act
            var result = companiesController.GetCompanyEntities() as OkObjectResult;
            var resultValue = result.Value as List<CompanyDTO>;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Single(resultValue);
            Assert.Equal("Title 1", resultValue[0].Title);

            mockCompanyService.Verify(m => m.GetCompanies());
        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsData))]
        public void GetCompany_Default_ShouldReturnCompany(CompanyDTO expected)
        {
            // Arrange
            MockCompanyService(new List<CompanyDTO> { expected });
            var companiesController = this.CreateCompaniesController();
            Guid id = expected.CompanyID;

            // Act
            var result = companiesController.GetCompany(
                id) as OkObjectResult;
            var resultValue = result.Value;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultValue);
            mockCompanyService.Verify(m => m.GetCompanyById(id));
        }

        [Fact]
        public void GetCompany_ThrowsException_ShouldCallErrorHandler()
        {
            // Arrange
            var e = new Exception();
            mockCompanyService.Setup(m => m.GetCompanyById(It.IsAny<Guid>())).Throws(e);
            mockErrorHandler.Setup(m => m.HandleError(It.IsAny<Exception>()));
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);

            // Act
            companiesController.GetCompany(id);

            // Assert
            mockCompanyService.Verify(m => m.GetCompanyById(id));
            mockErrorHandler.Verify(m => m.HandleError(e));

        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsData))]
        public void PutCompany_Default_ShouldCallCompanyServiceToUpdate(CompanyDTO expected)
        {
            // Arrange
            MockCompanyService(new List<CompanyDTO> { expected });
            var companiesController = this.CreateCompaniesController();
            Guid id = expected.CompanyID;
            CompanyDTO company = expected;

            // Act
            var result = companiesController.PutCompany(
                id,
                company) as NoContentResult;

            // Assert
            Assert.Equal(204, result.StatusCode);
            mockCompanyService.Verify(m => m.UpdateCompany(id, company));
        }

        [Fact]
        public void PutCompany_ThrowsException_ShouldCallErrorHandler()
        {
            // Arrange
            var e = new Exception();
            mockCompanyService.Setup(m => m.UpdateCompany(It.IsAny<Guid>(), It.IsAny<CompanyDTO>())).Throws(e);
            mockErrorHandler.Setup(m => m.HandleError(It.IsAny<Exception>()));
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            var company = new CompanyDTO();

            // Act
            companiesController.PutCompany(id, company);

            // Assert
            mockCompanyService.Verify(m => m.UpdateCompany(id, company));
            mockErrorHandler.Verify(m => m.HandleError(e));

        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsData))]
        public void PostCompany_Default_ShouldReturnCreatedCompany(CompanyDTO newCompany)
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            MockCompanyService(new List<CompanyDTO> { new CompanyDTO() });
            CompanyDTO company = newCompany;

            // Act
            var result = companiesController.PostCompany(
                company) as CreatedAtActionResult;

            // Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(company, result.Value);
            mockCompanyService.Verify(m => m.CreateCompany(company));
        }

        [Fact]
        public void PostCompany_ThrowsException_ShouldCallErrorHandler()
        {
            // Arrange
            var e = new Exception();
            mockCompanyService.Setup(m => m.CreateCompany(It.IsAny<CompanyDTO>())).Throws(e);
            mockErrorHandler.Setup(m => m.HandleError(It.IsAny<Exception>()));
            var companiesController = this.CreateCompaniesController();
            var company = new CompanyDTO();

            // Act
            companiesController.PostCompany(company);

            // Assert
            mockCompanyService.Verify(m => m.CreateCompany(company));
            mockErrorHandler.Verify(m => m.HandleError(e));

        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsData))]
        public void DeleteCompany_Default_ShouldReturnNoContentOnSuccess(CompanyDTO company)
        {
            // Arrange
            MockCompanyService(new List<CompanyDTO> { company });
            var companiesController = this.CreateCompaniesController();
            Guid id = company.CompanyID;

            // Act
            var result = companiesController.DeleteCompany(
                id) as NoContentResult;

            // Assert
            Assert.Equal(204, result.StatusCode);
            mockCompanyService.Verify(m => m.DeleteCompany(id));
        }

        [Fact]
        public void DeleteCompany_ThrowsException_ShouldCallErrorHandler()
        {
            // Arrange
            var e = new Exception();
            mockCompanyService.Setup(m => m.DeleteCompany(It.IsAny<Guid>())).Throws(e);
            mockErrorHandler.Setup(m => m.HandleError(It.IsAny<Exception>()));
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);

            // Act
            companiesController.DeleteCompany(id);

            // Assert
            mockCompanyService.Verify(m => m.DeleteCompany(id));
            mockErrorHandler.Verify(m => m.HandleError(e));

        }

        [Fact]
        public void GetJobAdvertisementEntities_Default_ShouldReturnListOfJobAdds()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            MockJobAdvertisementService(new List<JobAdvertisementDTO> { new JobAdvertisementDTO { Title = "Title 1" } });
            var id = new Guid();

            // Act
            var result = companiesController.GetJobAdvertisementEntities(id) as OkObjectResult;
            var resultValue = result.Value as List<JobAdvertisementDTO>;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Single(resultValue);
            Assert.Equal("Title 1", resultValue[0].Title);

            mockJobAdvertisementService.Verify(m => m.GetAdvertisementsByCompany(id));
        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsJobAddData))]
        public void GetJobAdvertisement_Default_ShouldReturnJobAdd(JobAdvertisementDTO expected)
        {
            // Arrange
            MockJobAdvertisementService(new List<JobAdvertisementDTO> { expected });
            var companiesController = this.CreateCompaniesController();
            var companyId = new Guid(expected.CompanyID.ToString());
            var id = new Guid(expected.JobAdvertisementID.ToString());

            // Act
            var result = companiesController.GetJobAdvertisement(companyId, id) as OkObjectResult;
            var resultValue = result.Value as JobAdvertisementDTO;

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, resultValue);
            Assert.Equal(companyId, resultValue.CompanyID);
            mockJobAdvertisementService.Verify(m => m.GetAdvertisementByCompany(companyId, id));
        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsJobAddData))]
        public void PutJobAdvertisement_Default_ShouldCallServiceToUpdate(JobAdvertisementDTO expected)
        {
            // Arrange
            MockJobAdvertisementService(new List<JobAdvertisementDTO> { expected });
            var companiesController = this.CreateCompaniesController();
            Guid id = new Guid(expected.CompanyID.ToString());
            Guid jobAddId = new Guid(expected.JobAdvertisementID.ToString());
            JobAdvertisementDTO jobAdvertisement = expected;

            // Act
            var result = companiesController.PutJobAdvertisement(
                id,
                jobAddId, jobAdvertisement) as NoContentResult;

            // Assert
            Assert.Equal(204, result.StatusCode);
            mockJobAdvertisementService.Verify(m => m.UpdateAdvertisement(id, jobAddId, jobAdvertisement));
        }

        [Theory]
        [ClassData(typeof(CompaniesControllerTestsJobAddData))]
        public void PostJobAdvertisement_Default_ShouldReturnCreatedJobAdd(JobAdvertisementDTO newJobAdd)
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            MockJobAdvertisementService(new List<JobAdvertisementDTO> { new JobAdvertisementDTO() });
            JobAdvertisementDTO jobAdd = newJobAdd;
            Guid id = new Guid(newJobAdd.CompanyID.ToString());

            // Act
            var result = companiesController.PostJobAdvertisement(id,
                jobAdd) as CreatedAtActionResult;

            // Assert
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(jobAdd, result.Value);
            mockJobAdvertisementService.Verify(m => m.CreateAdvertisement(id, jobAdd));
        }

        [Fact]
        public void DeleteJobAdvertisement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobId = default(global::System.Guid);

            // Act
            var result = companiesController.DeleteJobAdvertisement(
                id,
                jobId);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void GetCompanyJobSkills_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAdId = default(global::System.Guid);

            // Act
            var result = companiesController.GetCompanyJobSkills(
                id,
                jobAdId);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void GetCompanyAddJobId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid jobSkillId = default(global::System.Guid);

            // Act
            var result = companiesController.GetCompanyAddJobId(
                id,
                jobAddId,
                jobSkillId);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void PostJobSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            JobSkillDTO jobSkill = null;

            // Act
            var result = companiesController.PostJobSkill(
                id,
                jobAddId,
                jobSkill);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void DeleteJobSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid jobSkillId = default(global::System.Guid);

            // Act
            var result = companiesController.DeleteJobSkill(
                id,
                jobAddId,
                jobSkillId);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void GetApplicants_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);

            // Act
            var result = companiesController.GetApplicants(
                id,
                jobAddId);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void UpdateStatus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var companiesController = this.CreateCompaniesController();
            Guid id = default(global::System.Guid);
            Guid jobAddId = default(global::System.Guid);
            Guid applicationId = default(global::System.Guid);
            ApplicationStatus applicationStatus = default(global::CvApi.Models.Enums.ApplicationStatus);

            // Act
            var result = companiesController.UpdateStatus(
                id,
                jobAddId,
                applicationId,
                applicationStatus);

            // Assert
            Assert.True(true);
        }
    }
}
