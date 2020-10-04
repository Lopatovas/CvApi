using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using CvApi.Services.CoverLetterService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverLettersController : ControllerBase
    {
        private readonly CVContext _context;
        private readonly ICoverLetterService _service;

        public CoverLettersController(CVContext context, ICoverLetterService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCoverLetters()
        {
            var letters = _service.GetCoverLetters();
            return Ok(letters);
        }

        [HttpGet("{id}")]
        public IActionResult GetCoverLetter(Guid id)
        {
            try
            {
                var letter = _service.GetCoverLetterById(id);
                return Ok(letter);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCoverLetter(Guid id, [FromBody] CoverLetter coverLetter)
        {
            try
            {
                _service.UpdateCoverLetter(id, coverLetter);
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
        public IActionResult PostCoverLetter([FromBody] CoverLetter coverLetter)
        {
            _service.CreateCoverLetter(coverLetter);

            return CreatedAtAction("GetCoverLetter", new { id = coverLetter.CoverLetterID }, coverLetter);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoverLetter(Guid id)
        {
            try
            {
                _service.DeleteCoverLetter(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
