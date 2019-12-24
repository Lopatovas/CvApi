using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvApi.Models.Contexts;
using CvApi.Models.Entities;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverLettersController : ControllerBase
    {
        private readonly CVContext _context;

        public CoverLettersController(CVContext context)
        {
            _context = context;
        }

        // GET: api/CoverLetters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoverLetter>>> GetCoverLetterEntities()
        {
            return await _context.CoverLetterEntities.ToListAsync();
        }

        // GET: api/CoverLetters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoverLetter>> GetCoverLetter(long id)
        {
            var coverLetter = await _context.CoverLetterEntities.FindAsync(id);

            if (coverLetter == null)
            {
                return NotFound();
            }

            return coverLetter;
        }

        // PUT: api/CoverLetters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoverLetter(long id, CoverLetter coverLetter)
        {
            if (id != coverLetter.CoverLetterID)
            {
                return BadRequest();
            }

            _context.Entry(coverLetter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoverLetterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CoverLetters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CoverLetter>> PostCoverLetter(CoverLetter coverLetter)
        {
            _context.CoverLetterEntities.Add(coverLetter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoverLetter", new { id = coverLetter.CoverLetterID }, coverLetter);
        }

        // DELETE: api/CoverLetters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoverLetter>> DeleteCoverLetter(long id)
        {
            var coverLetter = await _context.CoverLetterEntities.FindAsync(id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            _context.CoverLetterEntities.Remove(coverLetter);
            await _context.SaveChangesAsync();

            return coverLetter;
        }

        private bool CoverLetterExists(long id)
        {
            return _context.CoverLetterEntities.Any(e => e.CoverLetterID == id);
        }
    }
}
