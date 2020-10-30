using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities.ResolvingTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.JobAdvertisementService
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        private readonly CVContext _context;
        private readonly IMapper _mapper;

        public JobAdvertisementService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public JobAdvertisementDTO CreateAdvertisement(Guid companyId, JobAdvertisementDTO advertisement)
        {
            var mapped = _mapper.Map<JobAdvertisement>(advertisement);
            var company = _context.CompanyEntities.Find(companyId);
            if (company == null)
            {
                throw new KeyNotFoundException();
            }
            mapped.CompanyID = companyId;
            _context.JobAdvertisementEntities.Add(mapped);
            _context.SaveChanges();
            var response = advertisement;
            response.JobAdvertisementID = mapped.JobAdvertisementID;
            return response;
        }

        public void DeleteAdvertisement(Guid companyId, Guid id)
        {
            var advertisement = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == id).FirstOrDefault();
            if (advertisement == null)
            {
                throw new KeyNotFoundException();
            }

            _context.JobAdvertisementEntities.Remove(advertisement);
            _context.SaveChanges();

        }

        public JobAdvertisementDTO GetAdvertisementByCompany(Guid companyId, Guid id)
        {
            var advertisement = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == id).FirstOrDefault();

            if (advertisement == null)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<JobAdvertisementDTO>(advertisement);

            return mapped;
        }

        public JobAdvertisementDTO GetAdvertisementById(Guid id)
        {
            var advertisement = _context.JobAdvertisementEntities.Find(id);

            if (advertisement == null)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<JobAdvertisementDTO>(advertisement);

            return mapped;
        }

        public IList<JobAdvertisementDTO> GetAdvertisements()
        {
            var response = _context.JobAdvertisementEntities.ToList();
            var mapped = _mapper.Map<IList<JobAdvertisementDTO>>(response);
            return mapped;
        }

        public IList<JobAdvertisementDTO> GetAdvertisementsByCompany(Guid companyId)
        {
            var response = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId).ToList();
            var mapped = _mapper.Map<IList<JobAdvertisementDTO>>(response);
            return mapped;
        }

        public void UpdateAdvertisement(Guid companyId, Guid id, JobAdvertisementDTO advertisement)
        {
            if (id != advertisement.JobAdvertisementID || companyId != advertisement.CompanyID)
            {
                throw new ArgumentException();
            }

            var mapped = _mapper.Map<JobAdvertisement>(advertisement);
            var advertisementInDb = _context.JobAdvertisementEntities.Where(item => item.CompanyID == companyId && item.JobAdvertisementID == id).First();
            if (advertisementInDb == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                _context.Entry(advertisementInDb).CurrentValues.SetValues(mapped);
                _context.SaveChanges();
            }
        }
    }
}
