using CompanyManagement.BLL;
using CompanyManagement.IBLL;
using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyManagement.UIPortal.Controllers
{
    public class CompanyController : Controller
    {   //ICompanyService companyService = new CompanyService();

        private readonly ICompanyService companyService;

        //inject dependency 
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        // GET: Company
        public ActionResult Index()
        {
            return View(companyService.GetEntitiesByCondition(boolValue => true));
        }

        //GET : Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,OrganizationNumber,Notes")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.Id = Guid.NewGuid();
                companyService.Add(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

    }
}