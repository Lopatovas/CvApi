using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;
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

        public JobSkillDTO CreateJobSkill(Guid companyId, Guid jobAddId, JobSkillDTO skill)
        {
            var mapped = _mapper.Map<JobSkill>(skill);
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == jobAddId).FirstOrDefault();
            if (jobAdd == null)
            {
                throw new KeyNotFoundException();
            }
            _context.JobSkillEntities.Add(mapped);
            _context.SaveChanges();
            var response = skill;
            response.JobAdvertisementID = mapped.JobAdvertisementID;
            return response;
        }

        public void DeleteJobSkill(Guid companyId, Guid jobAddId, Guid id)
        {
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == jobAddId).FirstOrDefault();
            var jobSkill = _context.JobSkillEntities.Find(id);

            if (jobSkill == null || jobAdd == null || jobSkill.JobAdvertisementID != jobAdd.JobAdvertisementID)
            {
                throw new KeyNotFoundException();
            }
            _context.JobSkillEntities.Remove(jobSkill);
            _context.SaveChanges();
        }

        public JobSkillDTO GetJobSkillById(Guid companyId, Guid jobAddId, Guid id)
        {
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == jobAddId).FirstOrDefault();
            var jobSkill = _context.JobSkillEntities.Find(id);

            if (jobSkill == null || jobAdd == null || jobSkill.JobAdvertisementID != jobAdd.JobAdvertisementID)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<JobSkillDTO>(jobSkill);

            return mapped;
        }

        public IList<JobSkillDTO> GetJobSkills(Guid companyId, Guid id)
        {
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == id).FirstOrDefault();
            var jobSkill = _context.JobSkillEntities.Where(item => item.JobAdvertisementID == id).ToList();

            if (jobSkill == null || jobAdd == null)
            {
                throw new KeyNotFoundException();
            }
            var mapped = _mapper.Map<IList<JobSkillDTO>>(jobSkill);
            return mapped;
        }

        public void UpdateJobSkill(Guid companyId, Guid jobAddId, Guid id, JobSkillDTO skill)
        {
            if (id != skill.JobSkillID || jobAddId != skill.JobAdvertisementID)
            {
                throw new ArgumentException();
            }

            var mapped = _mapper.Map<JobSkill>(skill);

            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == jobAddId).FirstOrDefault();
            var jobSkill = _context.JobSkillEntities.Find(id);

            if (jobSkill == null || jobAdd == null || jobSkill.JobAdvertisementID != jobAdd.JobAdvertisementID)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                _context.Entry(jobSkill).CurrentValues.SetValues(mapped);
                _context.SaveChanges();
            }
        }
    }
}
