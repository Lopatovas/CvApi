using CvApi.Models.Contexts;
using CvApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {

        private readonly CVContext _context;

        public CompanyService(CVContext context)
        {
            _context = context;
        }

        public void DeleteCompany(long id)
        {
            var company = _context.CompanyEntities.Find(id);
            if (company == null)
            {
                throw new KeyNotFoundException();
            }

            _context.CompanyEntities.Remove(company);
            _context.SaveChanges();
        }

        public IList<Company> GetCompanies()
        {
            var response = _context.CompanyEntities.ToList();
            return response;
        }

        public Company GetCompanyById(long id)
        {
            var company = _context.CompanyEntities.Find(id);

            if (company == null)
            {
                throw new KeyNotFoundException();
            }

            return company;
        }

        public void UpdateCompany(long id, Company company)
        {
            if (id != company.CompanyID)
            {
                throw new ArgumentException();
            }

            _context.Entry(company).State = EntityState.Modified;

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

        public void CreateCompany(Company company)
        {
            _context.CompanyEntities.Add(company);
            _context.SaveChanges();
        }

        private bool CompanyExists(long id)
        {
            return _context.CompanyEntities.Any(e => e.CompanyID == id);
        }
    }
}
