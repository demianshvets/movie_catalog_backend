using Microsoft.EntityFrameworkCore;
using Movie_catalog_react.Abstract;
using Movie_catalog_react.Entities;
using Movie_catalog_react.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Concrete
{
    public class CompanyRepository : ICompanyRepository

    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Company> Companies
        {
            get
            {
                return _context.Companies/*.Include(g => g.Movies)*/;
            }
        }
        public void addCompany(string name)
        {
            if (name != null)
            {
                _context.Add(new Company { Name = name });
                _context.SaveChanges();
            }
        }

        public void FillingCompaniesId(List<int> companiesId)
        {
            if (companiesId.Count == 0)
            {
                foreach (Company c in _context.Companies)
                    companiesId.Add(c.CompId);
            }
        }

        public void GetListCompaniesModel(List<Company> inputCompanies, List<CompanyModel> outputCompanies)
        {
            outputCompanies.Clear();
            foreach (Company c in inputCompanies)
            {
                outputCompanies.Add(new CompanyModel() { companyId = c.CompId.ToString(), companyName = c.Name.ToString() });
            }

        }

        public void FilteredCompany(List<int> companiesID, string inputCompanyId)
        {
            if (inputCompanyId != null)
            {
                companiesID.Clear();
                if (inputCompanyId == "all")
                {
                    this.FillingCompaniesId(companiesID);
                }
                else
                {
                    companiesID.Add(int.Parse(inputCompanyId));
                }
            }
        }
    }
}
