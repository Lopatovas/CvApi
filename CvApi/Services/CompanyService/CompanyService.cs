using AutoMapper;
using CvApi.Models.Contexts;
using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvApi.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {

        private readonly CVContext _context;
        private readonly IMapper _mapper;

        public CompanyService(CVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteCompany(Guid id)
        {
            var company = _context.CompanyEntities.Find(id);
            if (company == null)
            {
                throw new KeyNotFoundException();
            }

            _context.CompanyEntities.Remove(company);
            _context.SaveChanges();
        }

        public IList<CompanyDTO> GetCompanies()
        {
            var response = _context.CompanyEntities.ToList();
            var mapped = _mapper.Map<IList<CompanyDTO>>(response);
            return mapped;
        }

        public CompanyDTO GetCompanyById(Guid id)
        {
            var company = _context.CompanyEntities.Find(id);

            if (company == null)
            {
                throw new KeyNotFoundException();
            }

            var mapped = _mapper.Map<CompanyDTO>(company);

            return mapped;
        }

        public void UpdateCompany(Guid id, CompanyDTO company)
        {
            if (id != company.CompanyID)
            {
                throw new ArgumentException();
            }

            var mapped = _mapper.Map<Company>(company);

            _context.Entry(mapped).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void CreateCompany(CompanyDTO company)
        {
            var mapped = _mapper.Map<Company>(company);
            _context.CompanyEntities.Add(mapped);
            _context.SaveChanges();
        }

        private bool CompanyExists(Guid id)
        {
            return _context.CompanyEntities.Any(e => e.CompanyID == id);
        }
    }
}
