using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
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
        private readonly IMapper _mapper;

        public ExperienceService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateExperience(ExperienceDTO experience)
        {
            var mapped = _mapper.Map<Experience>(experience);
            _context.ExperienceEntities.Add(mapped);
            _context.SaveChangesAsync();
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

        public ExperienceDTO GetExperience(Guid id)
        {
            var response = _context.ExperienceEntities.Find(id);
            var mapped = _mapper.Map<ExperienceDTO>(response);
            return mapped;
        }

        public IList<ExperienceDTO> GetUserExperience(Guid id)
        {
            var response = _context.ExperienceEntities.Where(item => item.UserID == id).ToList();
            var mapped = _mapper.Map<IList<ExperienceDTO>>(response);
            return mapped;
        }

        public void UpdateExperience(Guid id, ExperienceDTO experience)
        {
            if (id != experience.ExperienceID)
            {
                throw new ArgumentException();
            }

            var mapped = _mapper.Map<Experience>(experience);
            _context.Entry(mapped).State = EntityState.Modified;

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
