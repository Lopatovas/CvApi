using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.JobSkillsService
{
    public interface IJobSkillsService
    {
        public IList<JobSkillDTO> GetJobSkills(Guid id);

        public JobSkillDTO GetJobSkillById(Guid id);

        public void UpdateJobSkill(Guid id, JobSkillDTO skill);

        public void CreateJobSkill(JobSkillDTO skill);

        public void DeleteJobSkill(Guid id);
    }
}
