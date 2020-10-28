using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.JobSkillsService
{
    public interface IJobSkillsService
    {
        public IList<JobSkillDTO> GetJobSkills(Guid companyId, Guid id);

        public JobSkillDTO GetJobSkillById(Guid companyId, Guid jobAddId, Guid id);

        public void UpdateJobSkill(Guid companyId, Guid jobAddId, Guid id, JobSkillDTO skill);

        public JobSkillDTO CreateJobSkill(Guid companyId, Guid jobAddId, JobSkillDTO skill);

        public void DeleteJobSkill(Guid companyId, Guid jobAddId, Guid id);
    }
}
