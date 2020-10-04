using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.ExperienceService
{
    public interface IExperienceService
    {
        public IList<Experience> GetUserExperience(Guid id);

        public Experience GetExperience(Guid id);

        public void UpdateExperience(Guid id, Experience experience);

        public void CreateExperience(Experience experience);

        public void DeleteExperience(Guid id);
    }
}
