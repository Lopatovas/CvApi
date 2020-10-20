using AutoMapper;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities.ResolvingTables;
using CvApi.Services.CompanyService;
using CvApi.Services.JobAdvertisementService;
using CvApi.Services.JobSkillsService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IJobSkillsService _jobSkillsService;
        private readonly IJobAdvertisementService _jobAddService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IJobSkillsService jobSkillsService, IJobAdvertisementService jobAddService, IMapper mapper)
        {
            _companyService = companyService;
            _jobSkillsService = jobSkillsService;
            _jobAddService = jobAddService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanyEntities()
        {
            var companies = _companyService.GetCompanies();
            return Ok(companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(Guid id)
        {
            try
            {
                var company = _companyService.GetCompanyById(id);
                return Ok(company);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCompany(Guid id, [FromBody] CompanyDTO company)
        {
            try
            {
                _companyService.UpdateCompany(id, company);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult PostCompany([FromBody] CompanyDTO company)
        {
            _companyService.CreateCompany(company);

            return CreatedAtAction("GetCompany", new { id = company.CompanyID }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(Guid id)
        {
            try
            {
                _companyService.DeleteCompany(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}/JobAdvertisements")]
        public IActionResult GetJobAdvertisementEntities()
        {
            var advertisements = _jobAddService.GetAdvertisements();
            return Ok(advertisements);
        }

        [HttpGet("{id}/JobAdvertisements/{addId}")]
        public IActionResult GetJobAdvertisement(Guid id, Guid addId)
        {
            try
            {
                var ids = id;
                var advertisement = _jobAddService.GetAdvertisementById(addId);
                return Ok(advertisement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/JobAdvertisements/{jobAddId}")]
        public IActionResult PutJobAdvertisement(Guid id, Guid jobAddId, [FromBody] JobAdvertisementDTO jobAdvertisement)
        {
            try
            {
                var ids = id;
                var mapped = _mapper.Map<JobAdvertisement>(jobAdvertisement);
                _jobAddService.UpdateAdvertisement(jobAddId, mapped);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{id}/JobAdvertisements")]
        public IActionResult PostJobAdvertisement(Guid id, [FromBody] JobAdvertisementDTO jobAdvertisement)
        {
            var mapped = _mapper.Map<JobAdvertisement>(jobAdvertisement);
            mapped.CompanyID = id;
            _jobAddService.CreateAdvertisement(mapped);

            return CreatedAtAction("GetJobAdvertisement", new { id = jobAdvertisement.JobAdvertisementID }, jobAdvertisement);
        }

        [HttpDelete("{id}/JobAdvertisements/{jobId}")]
        public IActionResult DeleteJobAdvertisement(Guid id, Guid jobId)
        {
            try
            {
                _jobAddService.DeleteAdvertisement(jobId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}/JobAdvertisements/{jobAdId}/JobSkills")]
        public IActionResult GetCompanyJobSkills(Guid id, Guid jobAdId)
        {
            try
            {
                var jobSkills = _jobSkillsService.GetJobSkills(jobAdId);
                return Ok(jobSkills);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/JobAdvertisements/{jobAdId}/JobSkills/{jobSkillId}")]
        public IActionResult GetCompanyAddJobId(Guid id, Guid jobAdId, Guid jobSkillId)
        {
            try
            {
                var jobSkills = _jobSkillsService.GetJobSkillById(jobSkillId);
                return Ok(jobSkills);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{id}/JobAdvertisements/{jobAdId}/JobSkills")]
        public IActionResult PostJobSkill(Guid id, Guid jobAdId, [FromBody] JobSkillDTO jobSkill)
        {
            try
            {
                jobSkill.JobAdvertisementID = jobAdId;
                _jobSkillsService.CreateJobSkill(jobSkill);
                return CreatedAtAction("PostJobSkill", jobSkill);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/JobAdvertisements/{jobAdId}/JobSkills/{jobSkillId}")]
        public IActionResult DeleteJobSkill(Guid id, Guid jobAdId, Guid jobSkillId)
        {
            try
            {
                _jobSkillsService.DeleteJobSkill(jobSkillId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
