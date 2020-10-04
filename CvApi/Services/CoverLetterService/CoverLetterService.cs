using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.CoverLetterService
{
    public class CoverLetterService : ICoverLetterService
    {
        private readonly CVContext _context;

        public CoverLetterService(CVContext context)
        {
            _context = context;
        }

        public void CreateCoverLetter(CoverLetter letter)
        {
            _context.CoverLetterEntities.Add(letter);
            _context.SaveChangesAsync();
        }

        public void DeleteCoverLetter(Guid id)
        {
            var letter = _context.CoverLetterEntities.Find(id);
            if (letter == null)
            {
                throw new KeyNotFoundException();
            }

            _context.CoverLetterEntities.Remove(letter);
            _context.SaveChanges();
        }

        public CoverLetter GetCoverLetterById(Guid id)
        {
            var coverLetter = _context.CoverLetterEntities.Find(id);

            if (coverLetter == null)
            {
                throw new KeyNotFoundException();
            }

            return coverLetter;
        }

        public IList<CoverLetter> GetCoverLetters()
        {
            var response = _context.CoverLetterEntities.ToList();
            return response;
        }

        public void UpdateCoverLetter(Guid id, CoverLetter letter)
        {
            if (id != letter.CoverLetterID)
            {
                throw new ArgumentException();
            }

            _context.Entry(letter).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoverLetterExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool CoverLetterExists(Guid id)
        {
            return _context.CoverLetterEntities.Any(e => e.CoverLetterID == id);
        }
    }
}
