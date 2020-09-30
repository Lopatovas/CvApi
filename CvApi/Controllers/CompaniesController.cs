using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using CvApi.Services.CompanyService;

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
        public IActionResult GetCompany(long id)
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
        public IActionResult PutCompany(long id, [FromBody] Company company)
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
        public IActionResult PostCompany([FromBody] Company company)
        {
            _companyService.CreateCompany(company);

            return CreatedAtAction("GetCompany", new { id = company.CompanyID }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(long id)
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
