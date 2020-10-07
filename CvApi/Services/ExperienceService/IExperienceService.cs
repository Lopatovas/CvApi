using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.ExperienceService
{
    public interface IExperienceService
    {
        public IList<ExperienceDTO> GetUserExperience(Guid id);

        public ExperienceDTO GetExperience(Guid id);

        public void UpdateExperience(Guid id, ExperienceDTO experience);

        public void CreateExperience(ExperienceDTO experience);

        public void DeleteExperience(Guid id);
    }
}
