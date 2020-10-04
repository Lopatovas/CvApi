using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.ExperienceService
{
    public class ExperienceService : IExperienceService
    {
        private readonly CVContext _context;

        public ExperienceService(CVContext context)
        {
            _context = context;
        }

        public void CreateExperience(Experience experience)
        {
            throw new NotImplementedException();
        }

        public void DeleteExperience(Guid id)
        {
            var experience = _context.ExperienceEntities.Find(id);
            if (experience == null)
            {
                throw new KeyNotFoundException();
            }

            _context.ExperienceEntities.Remove(experience);
            _context.SaveChanges();
        }

        public Experience GetExperience(Guid id)
        {
            var response = _context.ExperienceEntities.Find(id);
            return response;
        }

        public IList<Experience> GetUserExperience(Guid id)
        {
            var response = _context.ExperienceEntities.Where(item => item.UserID == id).ToList();
            return response;
        }

        public void UpdateExperience(Guid id, Experience experience)
        {
            if (id != experience.ExperienceID)
            {
                throw new ArgumentException();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool ExperienceExists(Guid id)
        {
            return _context.ExperienceEntities.Any(e => e.ExperienceID == id);
        }
    }
}
