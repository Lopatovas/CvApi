using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.JobSkillsService
{
    public class JobSkillsService : IJobSkillsService
    {
        private readonly CVContext _context;

        public JobSkillsService(CVContext context)
        {
            _context = context;
        }

        public void CreateJobSkill(JobSkill skill)
        {
            _context.JobSkillEntities.Add(skill);
            _context.SaveChanges();
        }

        public void DeleteJobSkill(Guid id)
        {
            var skill = _context.UserSkillEntities.Find(id);
            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            _context.UserSkillEntities.Remove(skill);
            _context.SaveChanges();
        }

        public JobSkill GetJobSkillById(Guid id)
        {
            var skill = _context.JobSkillEntities.Find(id);

            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            return skill;
        }

        public IList<JobSkill> GetJobSkills(Guid id)
        {
            var response = _context.JobSkillEntities.Where(item => item.JobAdvertisementID == id).ToList();
            return response;
        }

        public IList<UserSkill> GetUserSkills(Guid id)
        {
            var response = _context.UserSkillEntities.Where(item => item.UserID == id).ToList();
            return response;
        }

        public void UpdateJobSkill(Guid id, JobSkill skill)
        {
            if (id != skill.JobSkillID)
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
                if (!JobSkillExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool JobSkillExists(Guid id)
        {
            return _context.JobSkillEntities.Any(e => e.JobSkillID == id);
        }
    }
}
