using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.JobAdvertisementService
{
    public interface IJobAdvertisementService
    {
        public IList<JobAdvertisementDTO> GetAdvertisements();

        public IList<JobAdvertisementDTO> GetAdvertisementsByCompany(Guid companyId);

        public JobAdvertisementDTO GetAdvertisementById(Guid id);

        public JobAdvertisementDTO GetAdvertisementByCompany(Guid companyId, Guid id);

        public void UpdateAdvertisement(Guid companyId, Guid id, JobAdvertisementDTO advertisement);

        public JobAdvertisementDTO CreateAdvertisement(Guid companyId, JobAdvertisementDTO advertisement);

        public void DeleteAdvertisement(Guid companyId, Guid id);
    }
}
