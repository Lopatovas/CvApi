using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using CvApi.Services.SkillsService;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet]
        public IActionResult GetSkillEntities()
        {
            var skills = _skillsService.GetSkills();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public IActionResult GetSkill(long id)
        {
            try
            {
                var skill = _skillsService.GetSkillById(id);
                return Ok(skill);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutSkill(long id, [FromBody] Skill skill)
        {
            try
            {
                _skillsService.UpdateSkill(id, skill);
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
        public IActionResult PostSkill([FromBody] Skill skill)
        {
            _skillsService.CreateSkill(skill);

            return CreatedAtAction("GetSkill", new { id = skill.SkillID }, skill);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(long id)
        {
            try
            {
                _skillsService.DeleteSkill(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
