using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.UserSkillsService
{
    public interface IUserSkillsService
    {
        public IList<UserSkill> GetUserSkills(Guid id);

        public UserSkill GetSkillById(Guid id);

        public void UpdateSkill(Guid id, UserSkill userSkill);

        public void CreateSkill(UserSkill userSkill);

        public void DeleteUserSkill(Guid id);
    }
}
