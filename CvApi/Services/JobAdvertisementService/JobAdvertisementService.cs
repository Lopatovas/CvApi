using CvApi.Models.Contexts;
using CvApi.Models.Entities.ResolvingTables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.JobAdvertisementService
{
    public class JobAdvertisementService : IJobAdvertisementService
    {
        private readonly CVContext _context;

        public JobAdvertisementService(CVContext context)
        {
            _context = context;
        }

        public void CreateAdvertisement(JobAdvertisement advertisement)
        {
            _context.JobAdvertisementEntities.Add(advertisement);
            _context.SaveChangesAsync();
        }

        public void DeleteAdvertisement(Guid id)
        {
            var advertisement = _context.JobAdvertisementEntities.Find(id);
            if (advertisement == null)
            {
                throw new KeyNotFoundException();
            }

            _context.JobAdvertisementEntities.Remove(advertisement);
            _context.SaveChanges();
        }

        public JobAdvertisement GetAdvertisementById(Guid id)
        {
            var response = _context.JobAdvertisementEntities.Find(id);
            return response;
        }

        public IList<JobAdvertisement> GetAdvertisements()
        {
            var response = _context.JobAdvertisementEntities.ToList();
            return response;
        }

        public void UpdateAdvertisement(Guid id, JobAdvertisement advertisement)
        {
            if (id != advertisement.JobAdvertisementID)
            {
                throw new ArgumentException();
            }

            _context.Entry(advertisement).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool AdvertisementExists(Guid id)
        {
            return _context.JobAdvertisementEntities.Any(e => e.JobAdvertisementID == id);
        }
    }
}
