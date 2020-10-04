using CvApi.Models.DataTransferObject;
using System;
using System.Collections.Generic;

namespace CvApi.Services.CompanyService
{
    public interface ICompanyService
    {
        public IList<CompanyDTO> GetCompanies();

        public CompanyDTO GetCompanyById(Guid id);

        public void UpdateCompany(Guid id, CompanyDTO company);

        public void CreateCompany(CompanyDTO company);

        public void DeleteCompany(Guid id);
    }
}
