
using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.CoverLetterService
{
    public interface ICoverLetterService
    {
        public IList<CoverLetter> GetCoverLetters();

        public CoverLetter GetCoverLetterById(Guid id);

        public void UpdateCoverLetter(Guid id, CoverLetter letter);

        public void CreateCoverLetter(CoverLetter letter);

        public void DeleteCoverLetter(Guid id);
    }
}
