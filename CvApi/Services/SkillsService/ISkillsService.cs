using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.SkillsService
{
    public interface ISkillsService
    {
        public IList<Skill> GetSkills();

        public Skill GetSkillById(Guid id);

        public void UpdateSkill(Guid id, Skill skill);

        public void CreateSkill(Skill skill);

        public void DeleteSkill(Guid id);
    }
}
