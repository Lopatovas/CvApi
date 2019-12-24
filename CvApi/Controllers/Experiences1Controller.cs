﻿using System;
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
    public class Experiences1Controller : ControllerBase
    {
        private readonly CVContext _context;

        public Experiences1Controller(CVContext context)
        {
            _context = context;
        }

        // GET: api/Experiences1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperienceEntities()
        {
            return await _context.ExperienceEntities.ToListAsync();
        }

        // GET: api/Experiences1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(long id)
        {
            var experience = await _context.ExperienceEntities.FindAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            return experience;
        }

        // PUT: api/Experiences1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(long id, Experience experience)
        {
            if (id != experience.ExperienceID)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Experience>> PostExperience(Experience experience)
        {
            _context.ExperienceEntities.Add(experience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = experience.ExperienceID }, experience);
        }

        // DELETE: api/Experiences1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Experience>> DeleteExperience(long id)
        {
            var experience = await _context.ExperienceEntities.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.ExperienceEntities.Remove(experience);
            await _context.SaveChangesAsync();

            return experience;
        }

        private bool ExperienceExists(long id)
        {
            return _context.ExperienceEntities.Any(e => e.ExperienceID == id);
        }
    }
}