using CvApi.Models.Contexts;
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

        public UserSkillsService(CVContext context)
        {
            _context = context;
        }

        public void CreateSkill(UserSkill userSkill)
        {
            _context.UserSkillEntities.Add(userSkill);
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

        public UserSkill GetSkillById(Guid id)
        {
            var skill = _context.UserSkillEntities.Find(id);

            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            return skill;
        }

        public IList<UserSkill> GetUserSkills(Guid id)
        {
            var response = _context.UserSkillEntities.Where(item => item.UserID == id).ToList();
            return response;
        }

        public void UpdateSkill(Guid id, UserSkill userSkill)
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
