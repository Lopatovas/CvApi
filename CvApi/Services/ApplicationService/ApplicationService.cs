using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities.ResolvingTables;
using CvApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private readonly CVContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ApplicationDTO Apply(Guid jobAddId, ApplicationDTO application)
        {
            var mapped = _mapper.Map<Application>(application);
            var jobAdd = _context.JobAdvertisementEntities.Find(jobAddId);
            if (jobAdd == null)
            {
                throw new KeyNotFoundException();
            }
            mapped.JobAdvertisementID = jobAddId;
            _context.ApplicationEntities.Add(mapped);
            _context.SaveChanges();
            var response = application;
            response.ApplicationID = mapped.ApplicationID;
            return response;
        }

        public void DeleteApplication(Guid userId, Guid id)
        {
            var application = _context.ApplicationEntities.Where(item => item.UserID == userId && item.ApplicationID == id).FirstOrDefault();
            if (application == null)
            {
                throw new KeyNotFoundException();
            }

            _context.ApplicationEntities.Remove(application);
            _context.SaveChanges();
        }

        public IList<ApplicationDTO> GetApplicants(Guid companyId, Guid jobAddId)
        {
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == jobAddId).FirstOrDefault();
            var applicants = _context.ApplicationEntities
                    .Where(item => item.JobAdvertisementID == jobAdd.JobAdvertisementID)
                    .Join(
                        _context.UserEntities,
                        application => application.UserID,
                        user => user.UserID,
                        (application, user) => new ApplicationDTO
                        {
                            ApplicationID = application.ApplicationID,
                            UserID = application.UserID,
                            Username = $"{user.Name} {user.Surname}",
                            JobAdvertisementID = application.JobAdvertisementID,
                            CreatedAt = application.CreatedAt,
                            Status = application.Status,
                        })
                    .ToList();

            if (applicants == null || jobAdd == null)
            {
                throw new KeyNotFoundException();
            }
            return applicants;
        }

        public IList<ApplicationDTO> GetApplications(Guid userId)
        {
            var applications = _context.ApplicationEntities.Where(item => item.UserID == userId).ToList();
            var mapped = _mapper.Map<IList<ApplicationDTO>>(applications);
            return mapped;
        }

        public void UpdateStatus(Guid companyId, Guid jobAddId, Guid id, ApplicationStatus status)
        {
            var jobAdd = _context.JobAdvertisementEntities.Where(item => item.JobAdvertisementID == jobAddId && item.CompanyID == companyId).FirstOrDefault();
            var application = _context.ApplicationEntities.Find(id);
            if (jobAdd == null || application == null)
            {
                throw new KeyNotFoundException();
            }
            application.Status = status;
            _context.ApplicationEntities.Update(application);
            _context.SaveChanges();
        }
    }
}
