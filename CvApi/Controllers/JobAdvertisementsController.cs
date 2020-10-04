using CvApi.Models.Contexts;
using CvApi.Models.Entities.ResolvingTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementsController : ControllerBase
    {
        private readonly CVContext _context;

        public JobAdvertisementsController(CVContext context)
        {
            _context = context;
        }

        // GET: api/JobAdvertisements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobAdvertisement>>> GetJobAdvertisementEntities()
        {
            return await _context.JobAdvertisementEntities.ToListAsync();
        }

        // GET: api/JobAdvertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobAdvertisement>> GetJobAdvertisement(Guid id)
        {
            var jobAdvertisement = await _context.JobAdvertisementEntities.FindAsync(id);

            if (jobAdvertisement == null)
            {
                return NotFound();
            }

            return jobAdvertisement;
        }

        // PUT: api/JobAdvertisements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobAdvertisement(Guid id, [FromBody] JobAdvertisement jobAdvertisement)
        {
            if (id != jobAdvertisement.JobAdvertisementID)
            {
                return BadRequest();
            }

            _context.Entry(jobAdvertisement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdvertisementExists(id))
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

        // POST: api/JobAdvertisements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JobAdvertisement>> PostJobAdvertisement([FromBody] JobAdvertisement jobAdvertisement)
        {
            _context.JobAdvertisementEntities.Add(jobAdvertisement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobAdvertisement", new { id = jobAdvertisement.JobAdvertisementID }, jobAdvertisement);
        }

        // DELETE: api/JobAdvertisements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobAdvertisement>> DeleteJobAdvertisement(Guid id)
        {
            var jobAdvertisement = await _context.JobAdvertisementEntities.FindAsync(id);
            if (jobAdvertisement == null)
            {
                return NotFound();
            }

            _context.JobAdvertisementEntities.Remove(jobAdvertisement);
            await _context.SaveChangesAsync();

            return jobAdvertisement;
        }

        private bool JobAdvertisementExists(Guid id)
        {
            return _context.JobAdvertisementEntities.Any(e => e.JobAdvertisementID == id);
        }
    }
}
