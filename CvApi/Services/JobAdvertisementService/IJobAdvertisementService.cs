using CvApi.Models.Entities.ResolvingTables;
using System;
using System.Collections.Generic;

namespace CvApi.Services.JobAdvertisementService
{
    public interface IJobAdvertisementService
    {
        public IList<JobAdvertisement> GetAdvertisements();

        public JobAdvertisement GetAdvertisementById(Guid id);

        public void UpdateAdvertisement(Guid id, JobAdvertisement advertisement);

        public void CreateAdvertisement(JobAdvertisement advertisement);

        public void DeleteAdvertisement(Guid id);
    }
}
