using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.UserSkillsService
{
    public interface IUserSkillsService
    {
        public IList<UserSkillDTO> GetUserSkills(Guid id);

        public UserSkillDTO GetSkillById(Guid id);

        public void UpdateSkill(Guid id, UserSkillDTO userSkill);

        public void CreateSkill(UserSkillDTO userSkill);

        public void DeleteUserSkill(Guid id);
    }
}
