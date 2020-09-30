using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Services.SkillsService
{
    public class SkillsService : ISkillsService
    {
        private readonly CVContext _context;

        public SkillsService(CVContext context)
        {
            _context = context;
        }

        public void CreateSkill(Skill skill)
        {
            _context.SkillEntities.Add(skill);
            _context.SaveChanges();
        }

        public void DeleteSkill(long id)
        {
            var skill = _context.SkillEntities.Find(id);
            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            _context.SkillEntities.Remove(skill);
            _context.SaveChanges();
        }

        public Skill GetSkillById(long id)
        {
            var skill = _context.SkillEntities.Find(id);

            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            return skill;
        }

        public IList<Skill> GetSkills()
        {
            var response = _context.SkillEntities.ToList();
            return response;
        }

        public void UpdateSkill(long id, Skill skill)
        {
            if (id != skill.SkillID)
            {
                throw new ArgumentException();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool SkillExists(long id)
        {
            return _context.SkillEntities.Any(e => e.SkillID == id);
        }
    }
}
