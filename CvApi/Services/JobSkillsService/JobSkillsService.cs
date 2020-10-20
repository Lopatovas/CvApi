using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
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
        private readonly IMapper _mapper;

        public JobSkillsService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateJobSkill(JobSkillDTO skill)
        {
            var mapped = _mapper.Map<JobSkill>(skill);
            _context.JobSkillEntities.Add(mapped);
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

        public JobSkillDTO GetJobSkillById(Guid id)
        {
            var skill = _context.JobSkillEntities.Find(id);

            if (skill == null)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<JobSkillDTO>(skill);

            return mapped;
        }

        public IList<JobSkillDTO> GetJobSkills(Guid id)
        {
            var response = _context.JobSkillEntities.Where(item => item.JobAdvertisementID == id).ToList();
            var mapped = _mapper.Map<IList<JobSkillDTO>>(response);
            return mapped;
        }

        public IList<UserSkill> GetUserSkills(Guid id)
        {
            var response = _context.UserSkillEntities.Where(item => item.UserID == id).ToList();
            return response;
        }

        public void UpdateJobSkill(Guid id, JobSkillDTO skill)
        {
            if (id != skill.JobSkillID)
            {
                throw new ArgumentException();
            }

            var mapped = _mapper.Map<IList<JobSkill>>(skill);
            _context.Entry(mapped).State = EntityState.Modified;

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
