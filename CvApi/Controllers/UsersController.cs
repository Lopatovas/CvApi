﻿using CvApi.Helper;
using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Services.ApplicationService;
using CvApi.Services.ExperienceService;
using CvApi.Services.UserService;
using CvApi.Services.UserSkillsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CvApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;
        private IUserSkillsService _userSkillsService;
        private IExperienceService _userExperienceService;
        private readonly IApplicationService _applicationService;
        private readonly AppSettings _appSettings;
        private readonly IErrorHandler _handler;

        public UsersController(
            IUserService userService,
            IUserSkillsService userSkillsService,
            IExperienceService experienceService,
            IOptions<AppSettings> appSettings,
            IApplicationService applicationService,
            IErrorHandler handler
            )
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _userSkillsService = userSkillsService;
            _userExperienceService = experienceService;
            _applicationService = applicationService;
            _handler = handler;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody]UserDTO userDto)
        {
            var user = _userService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.UserID,
                user.Email,
                FirstName = user.Name,
                LastName = user.Surname,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDTO userDto)
        {

            try
            {
                string resp = _userService.Create(userDto, userDto.Password);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UserDTO userDto)
        {

            try
            {
                // save 
                _userService.Update(userDto, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/skills")]
        public IActionResult GetUserSkills(Guid id)
        {
            var userSkills = _userSkillsService.GetUserSkills(id);
            return Ok(userSkills);
        }

        [HttpGet("{id}/skills/{skillId}")]
        public IActionResult GetUserSkill(Guid _, Guid skillId)
        {
            try
            {
                var userSkill = _userSkillsService.GetSkillById(skillId);
                return Ok(userSkill);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost("{id}/skills")]
        public IActionResult CreateUserSkill(Guid id, [FromBody]UserSkillDTO userSkill)
        {
            userSkill.UserID = id;
            _userSkillsService.CreateSkill(userSkill);
            return CreatedAtAction("GetSkill", new { id = userSkill.SkillID }, userSkill);
        }

        [HttpPut("{id}/skills/{skillId}")]
        public IActionResult UpdateUserSkill(Guid id, Guid skillId, [FromBody]UserSkillDTO userSkill)
        {
            try
            {
                userSkill.UserID = id;
                userSkill.SkillID = skillId;
                _userSkillsService.UpdateSkill(skillId, userSkill);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpDelete("{id}/skills/{skillId}")]
        public IActionResult RemoveUserSkill(Guid _, Guid skillId)
        {
            try
            {
                _userSkillsService.DeleteUserSkill(skillId);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/experiences")]
        public IActionResult GetUserExperiences(Guid id)
        {
            var userExperiences = _userExperienceService.GetUserExperience(id);
            return Ok(userExperiences);
        }

        [HttpGet("{id}/experiences/{experienceId}")]
        public IActionResult GetUserExperience(Guid _, Guid experienceId)
        {
            try
            {
                var experience = _userExperienceService.GetExperience(experienceId);
                return Ok(experience);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost("{id}/experiences")]
        public IActionResult CreateUserExperience(Guid id, [FromBody]ExperienceDTO experience)
        {
            experience.UserID = id;
            _userExperienceService.CreateExperience(experience);
            return CreatedAtAction("GetExperience", new { id = experience.ExperienceID }, experience);
        }

        [HttpPut("{id}/experiences/{experienceId}")]
        public IActionResult UpdateUserExperience(Guid id, Guid experienceId, [FromBody]ExperienceDTO experience)
        {
            try
            {
                experience.UserID = id;
                experience.ExperienceID = experienceId;
                _userExperienceService.UpdateExperience(experienceId, experience);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpDelete("{id}/experiences/{experienceId}")]
        public IActionResult RemoveUserExperience(Guid _, Guid experienceId)
        {
            try
            {
                _userExperienceService.DeleteExperience(experienceId);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpGet("{id}/Applications")]
        public IActionResult GetApplicants(Guid id)
        {
            try
            {
                var applicatants = _applicationService.GetApplications(id);
                return Ok(applicatants);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpDelete("{id}/applications/{applicationId}")]
        public IActionResult RemoveApplication(Guid id, Guid applicationId)
        {
            try
            {
                _applicationService.DeleteApplication(id, applicationId);
                return NoContent();
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }
    }
}
