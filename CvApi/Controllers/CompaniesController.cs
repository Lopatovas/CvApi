using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Enums;
using CvApi.Services.ApplicationService;
using CvApi.Services.CompanyService;
using CvApi.Services.JobAdvertisementService;
using CvApi.Services.JobSkillsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Company")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IJobSkillsService _jobSkillsService;
        private readonly IJobAdvertisementService _jobAddService;
        private readonly IErrorHandler _handler;
        private readonly IApplicationService _applicationService;

        public CompaniesController(ICompanyService companyService, IJobSkillsService jobSkillsService, IJobAdvertisementService jobAddService, IErrorHandler handler, IApplicationService applicationService)
        {
            _companyService = companyService;
            _jobSkillsService = jobSkillsService;
            _jobAddService = jobAddService;
            _handler = handler;
            _applicationService = applicationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCompanyEntities()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetCompany(Guid id)
        {
            try
            {
                var company = _companyService.GetCompanyById(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCompany(Guid id, [FromBody] CompanyDTO company)
        {
            try
            {
                _companyService.UpdateCompany(id, company);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody] CompanyDTO company)
        {
            try
            {
                var newCompany = _companyService.CreateCompany(company);
                return CreatedAtAction("GetCompany", new { id = newCompany.CompanyID }, newCompany);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            try
            {
                _companyService.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/JobAdvertisements")]
        public IActionResult GetJobAdvertisementEntities(Guid id)
        {
            var advertisements = _jobAddService.GetAdvertisementsByCompany(id);
            return Ok(advertisements);
        }

        [HttpGet("{id}/JobAdvertisements/{addId}")]
        public IActionResult GetJobAdvertisement(Guid id, Guid addId)
        {
            try
            {
                var ids = id;
                var advertisement = _jobAddService.GetAdvertisementByCompany(id, addId);
                return Ok(advertisement);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPut("{id}/JobAdvertisements/{jobAddId}")]
        public IActionResult PutJobAdvertisement(Guid id, Guid jobAddId, [FromBody] JobAdvertisementDTO jobAdvertisement)
        {
            try
            {
                _jobAddService.UpdateAdvertisement(id, jobAddId, jobAdvertisement);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost("{id}/JobAdvertisements")]
        public IActionResult PostJobAdvertisement(Guid id, [FromBody] JobAdvertisementDTO jobAdvertisement)
        {
            try
            {
                var newJobAdd = _jobAddService.CreateAdvertisement(id, jobAdvertisement);
                return CreatedAtAction("GetJobAdvertisement", new { id = newJobAdd.CompanyID, addId = newJobAdd.JobAdvertisementID }, jobAdvertisement);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpDelete("{id}/JobAdvertisements/{jobId}")]
        public IActionResult DeleteJobAdvertisement(Guid id, Guid jobId)
        {
            try
            {
                _jobAddService.DeleteAdvertisement(id, jobId);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/JobAdvertisements/{jobAdId}/JobSkills")]
        [AllowAnonymous]
        public IActionResult GetCompanyJobSkills(Guid id, Guid jobAdId)
        {
            try
            {
                var jobSkills = _jobSkillsService.GetJobSkills(id, jobAdId);
                return Ok(jobSkills);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/JobAdvertisements/{jobAddId}/JobSkills/{jobSkillId}")]
        public IActionResult GetCompanyAddJobId(Guid id, Guid jobAddId, Guid jobSkillId)
        {
            try
            {
                var jobSkills = _jobSkillsService.GetJobSkillById(id, jobAddId, jobSkillId);
                return Ok(jobSkills);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost("{id}/JobAdvertisements/{jobAddId}/JobSkills")]
        public IActionResult PostJobSkill(Guid id, Guid jobAddId, [FromBody] JobSkillDTO jobSkill)
        {
            try
            {
                _jobSkillsService.CreateJobSkill(id, jobAddId, jobSkill);
                return CreatedAtAction("PostJobSkill", jobSkill);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpDelete("{id}/JobAdvertisements/{jobAddId}/JobSkills/{jobSkillId}")]
        public IActionResult DeleteJobSkill(Guid id, Guid jobAddId, Guid jobSkillId)
        {
            try
            {
                _jobSkillsService.DeleteJobSkill(id, jobAddId, jobSkillId);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/JobAdvertisements/{jobAddId}/Applications")]
        public IActionResult GetApplicants(Guid id, Guid jobAddId)
        {
            try
            {
                var applicatants = _applicationService.GetApplicants(id, jobAddId);
                return Ok(applicatants);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPut("{id}/JobAdvertisements/{jobAddId}/Applications/{applicationId}")]
        public IActionResult UpdateStatus(Guid id, Guid jobAddId, Guid applicationId, [FromBody] ApplicationStatus applicationStatus)
        {
            try
            {
                _applicationService.UpdateStatus(id, jobAddId, applicationId, applicationStatus);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }
    }
}
