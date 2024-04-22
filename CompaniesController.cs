using ITcompanyDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITcompanyDB.Controllers
{
    public class CompaniesController : Controller
    {
        public IActionResult Index(bool useInternalMethod = false)
        {
            ViewData["UseInternalMethod"] = useInternalMethod;

            var companies = CompaniesRepository.GetCompanies();
            return View(companies);
        }

        public IActionResult Edit(int? id) 
        {
            ViewBag.Action = "edit";

            var company = CompaniesRepository.GetCompanyById(id.HasValue?id.Value:0);

            return View(company);
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                CompaniesRepository.UpdateCompany(company.CompanyId, company);

                return RedirectToAction(nameof(Index));
            }
            
            return View(company);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        [HttpPost]
        public IActionResult Add(Company company) 
        {
            if (ModelState.IsValid)
            {
                CompaniesRepository.AddCompany(company);

                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        public IActionResult Delete(int companyId) 
        {
            CompaniesRepository.DeleteCompany(companyId);
            return RedirectToAction(nameof(Index));
        }
    }
}
