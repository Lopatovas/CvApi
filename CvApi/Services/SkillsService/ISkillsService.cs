using CvApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Services.SkillsService
{
    public interface ISkillsService
    {
        public IList<Skill> GetSkills();

        public Skill GetSkillById(long id);

        public void UpdateSkill(long id, Skill company);

        public void CreateSkill(Skill company);

        public void DeleteSkill(long id);
    }
}
