using CvApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvApi.Services.CompanyService
{
    public interface ICompanyService
    {
        public IList<Company> GetCompanies();

        public Company GetCompanyById(long id);

        public void UpdateCompany(long id, Company company);

        public void CreateCompany(Company company);

        public void DeleteCompany(long id);
    }
}
