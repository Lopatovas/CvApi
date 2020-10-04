using CvApi.Models.DataTransferObject;
using CvApi.Services.CompanyService;
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

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
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
            return Ok();
        }
    }
}
