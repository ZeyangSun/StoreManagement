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
    {
        // GET: Company
        ICompanyService companyService = new CompanyService();
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
                companyService.Add(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

    }
}