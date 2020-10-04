using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using CvApi.Services.ExperienceService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly CVContext _context;
        private readonly IExperienceService _service;

        public ExperiencesController(CVContext context, IExperienceService service)
        {
            _context = context;
            _service = service;
        }


        [HttpGet("{id}")]
        public IActionResult GetExperience(Guid id)
        {
            try
            {
                var experience = _service.GetExperience(id);
                return Ok(experience);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutExperience(Guid id, [FromBody] Experience experience)
        {
            try
            {
                _service.UpdateExperience(id, experience);
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
        public IActionResult PostExperience([FromBody] Experience experience)
        {
            _service.CreateExperience(experience);

            return CreatedAtAction("GetExperience", new { id = experience.ExperienceID }, experience);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(Guid id)
        {
            try
            {
                _service.DeleteExperience(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
