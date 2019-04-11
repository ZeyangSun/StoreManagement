using CompanyManagement.BLL;
using CompanyManagement.IBLL;
using CompanyManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = companyService.FindById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
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

        //GET Company/Edit/id
        public ActionResult Edit(Guid? Id)
        {
            if(Id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Company company = companyService.FindById(Id);
            if (company == null)
                return HttpNotFound();
            return View(company);
        }

        //POST Company/Edit/id
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Company company)
        {
            if(companyService.Update(company))
                return RedirectToAction("Index");
            return View(company);

        }

        // GET: Companies/Delete/id
        public ActionResult Delete(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Company company = companyService.FindById(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid? id)
        {
            try
            {
                Company company = companyService.FindById(id);
                companyService.Delete(company);
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

    }

}