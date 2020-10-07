using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.UserSkillsService
{
    public class UserSkillsService : IUserSkillsService
    {
        private readonly CVContext _context;
        private readonly IMapper _mapper;

        public UserSkillsService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateSkill(UserSkillDTO userSkill)
        {
            var mapped = _mapper.Map<UserSkill>(userSkill);
            _context.UserSkillEntities.Add(mapped);
            _context.SaveChanges();
        }

        public void DeleteUserSkill(Guid id)
        {
            var skill = _context.UserSkillEntities.Find(id);
            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            _context.UserSkillEntities.Remove(skill);
            _context.SaveChanges();
        }

        public UserSkillDTO GetSkillById(Guid id)
        {
            var skill = _context.UserSkillEntities.Find(id);

            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<UserSkillDTO>(skill);

            return mapped;
        }

        public IList<UserSkillDTO> GetUserSkills(Guid id)
        {
            var response = _context.UserSkillEntities.Where(item => item.UserID == id).ToList();
            var mapped = _mapper.Map<IList<UserSkillDTO>>(response);
            return mapped;
        }

        public void UpdateSkill(Guid id, UserSkillDTO userSkill)
        {
            if (id != userSkill.UserSkillID)
            {
                throw new ArgumentException();
            }

            _context.Entry(userSkill).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSkillExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool UserSkillExists(Guid id)
        {
            return _context.UserSkillEntities.Any(e => e.UserSkillID == id);
        }
    }
}
