using CvApi.Models.DataTransferObject;
using CvApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace CvApi.Services.ApplicationService
{
    public interface IApplicationService
    {
        public IList<ApplicationDTO> GetApplicants(Guid companyId, Guid jobAddId);

        public void UpdateStatus(Guid companyId, Guid jobAddId, Guid id, ApplicationStatus status);

        public ApplicationDTO Apply(Guid jobAddId, ApplicationDTO application);

        public void DeleteApplication(Guid userId, Guid id);

        public IList<ApplicationDTO> GetApplications(Guid userId);
    }
}
