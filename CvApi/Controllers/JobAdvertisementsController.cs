using CvApi.Models.Contexts;
using CvApi.Models.Entities.ResolvingTables;
using CvApi.Services.JobAdvertisementService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementsController : ControllerBase
    {
        private readonly CVContext _context;
        private readonly IJobAdvertisementService _service;

        public JobAdvertisementsController(CVContext context, IJobAdvertisementService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetJobAdvertisementEntities()
        {
            var advertisements = _service.GetAdvertisements();
            return Ok(advertisements);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobAdvertisement(Guid id)
        {
            try
            {
                var advertisement = _service.GetAdvertisementById(id);
                return Ok(advertisement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutJobAdvertisement(Guid id, [FromBody] JobAdvertisement jobAdvertisement)
        {
            try
            {
                _service.UpdateAdvertisement(id, jobAdvertisement);
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
        public IActionResult PostJobAdvertisement([FromBody] JobAdvertisement jobAdvertisement)
        {
            _service.CreateAdvertisement(jobAdvertisement);

            return CreatedAtAction("GetJobAdvertisement", new { id = jobAdvertisement.JobAdvertisementID }, jobAdvertisement);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJobAdvertisement(Guid id)
        {
            try
            {
                _service.DeleteAdvertisement(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
