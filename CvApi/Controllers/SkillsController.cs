using CvApi.Models.Entities;
using CvApi.Services.SkillsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSkillEntities()
        {
            var skills = _skillsService.GetSkills();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetSkill(Guid id)
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
        [Authorize(Policy = "Admin")]
        public IActionResult PutSkill(Guid id, [FromBody] Skill skill)
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
        [Authorize(Policy = "Users")]
        public IActionResult PostSkill([FromBody] Skill skill)
        {
            _skillsService.CreateSkill(skill);

            return CreatedAtAction("GetSkill", new { id = skill.SkillID }, skill);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult DeleteSkill(Guid id)
        {
            try
            {
                _skillsService.DeleteSkill(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
