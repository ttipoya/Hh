using System.ComponentModel.Design;

namespace ITcompanyDB.Models
{
    public static class CompaniesRepository
    {
        private static List<Company> _companies = new List<Company>()
        {
            new Company{CompanyId = 1, CompanyName = "First", FoundedDate = DateTime.Today, Type = "Cool", EmployeeCount = 10, Revenue = 200000},
            new Company{CompanyId = 2, CompanyName = "Second", FoundedDate = DateTime.Today, Type = "Cool", EmployeeCount = 10, Revenue = 200000},
            new Company{CompanyId = 3, CompanyName = "Third", FoundedDate = DateTime.Today, Type = "Cool", EmployeeCount = 10, Revenue = 200000}
        };

        public static void AddCompany(Company company)
        {
            var maxId = _companies.Max(x => x.CompanyId);
            company.CompanyId = maxId + 1;
            _companies.Add(company);
        }

        public static List<Company> GetCompanies() => _companies;

        public static Company? GetCompanyById(int companyId)
        {
            var company = _companies.FirstOrDefault(x => x.CompanyId == companyId);
            if (company != null)
            {
                return new Company
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    FoundedDate = company.FoundedDate,
                    Type = company.Type,
                    EmployeeCount = company.EmployeeCount,
                    Revenue = company.Revenue,
                };
            }

            return null;
        }

        public static void UpdateCompany(int companyId, Company company)
        {
            if (companyId != company.CompanyId) return;

            var companyToUpdate = _companies.FirstOrDefault(x => x.CompanyId == companyId);
            if (companyToUpdate != null) 
            {
                companyToUpdate.CompanyName = company.CompanyName;
                companyToUpdate.FoundedDate = company.FoundedDate;
                companyToUpdate.Type = company.Type;
                companyToUpdate.EmployeeCount = company.EmployeeCount;
                companyToUpdate.Revenue = company.Revenue;
            }
        }

        public static void DeleteCompany(int companyId)
        {
            var company = _companies.FirstOrDefault(x =>x.CompanyId == companyId);
            if (company != null) 
            { 
                _companies.Remove(company);
            }
        }
    }
}
