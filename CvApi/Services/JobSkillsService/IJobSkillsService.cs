using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.JobSkillsService
{
    public interface IJobSkillsService
    {
        public IList<JobSkill> GetJobSkills(Guid id);

        public JobSkill GetJobSkillById(Guid id);

        public void UpdateJobSkill(Guid id, JobSkill skill);

        public void CreateJobSkill(JobSkill skill);

        public void DeleteJobSkill(Guid id);
    }
}
