using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Abstract
{
    interface ICompanyRepository
    {
        IEnumerable<Company> Companies { get; }
        void FillingCompaniesId(List<int> companiesId);
        void FilteredCompany(List<int> companiesID, string inputCompanyId);
        void GetListCompaniesModel(List<Company> inputCompanies, List<CompanyModel> outputCompanies);
        public void addCompany(string name);
    }
}
