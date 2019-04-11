using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CompanyManagement.Common;
using CompanyManagement.IBLL;
using CompanyManagement.Model;

namespace CompanyManagement.UIPortal.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        private readonly ICompanyService companyService;
        private readonly IGeocodingAPI geocodingAPI;

        //inject dependency 
        public StoreController(IStoreService storeService, ICompanyService companyService, IGeocodingAPI geocodingAPI)
        {
            this.storeService = storeService;
            this.companyService = companyService;
            this.geocodingAPI = geocodingAPI;
        }

        // GET: Store
        public ActionResult Index()
        {
            var stores = storeService.GetEntitiesByCondition(u => u.Company.Id !=null );//db.Stores.Include(s => s.Company);
            return View(stores);
        }

        // GET: Store/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = storeService.FindById(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetEntitiesByCondition(u => true).ToList(), "Id", "Name");
            return View();
        }

        //POST: Store/GetGeoInfo
        [HttpPost]
        
        public PartialViewResult GetGeoInfo(Guid? Id,string address,string city)
        {
         
                Store store = storeService.FindById(Id);
                System.Diagnostics.Debug.WriteLine("---------------  " +store.Address+"....."+store.City );
                GeoObject geoObject = geocodingAPI.GetGeoObject(store.Address + " " + store.City);
            
                System.Diagnostics.Debug.WriteLine("---------------  " + geoObject.Latitude + "....." + geoObject.Longitude);
                return PartialView("GetGeoInfo", geoObject);
            
            
            
        }
        public JsonResult GetGeoInfoNew(string address, string city)
        {
            if (String.IsNullOrEmpty(address) || String.IsNullOrEmpty(city))
                return Json(false);
            GeoObject geoObject = geocodingAPI.GetGeoObject(address + " " + city);
            return Json(geoObject);
        }
        // POST: Store/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyId,Name,Address,City,Zip,Country,Longitude,Latitude")] Store store)
        {
            if (ModelState.IsValid)
            {
                store.Id = Guid.NewGuid();
                storeService.Add(store);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetEntitiesByCondition(u => true).ToList(), "Id", "Name", store.CompanyId);
            return View(store);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = storeService.FindById(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetEntitiesByCondition(u => true).ToList(), "Id", "Name", store.CompanyId);
            return View(store);
        }

        // POST: Store/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyId,Name,Address,City,Zip,Country,Longitude,Latitude")] Store store)
        {
            if (ModelState.IsValid)
            {
                storeService.Update(store);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetEntitiesByCondition(u => true).ToList(), "Id", "Name", store.CompanyId);
            return View(store);
        }

        [HttpPost]
        public JsonResult IsValidZip(string address,string city,string zip)
        {
            string errorMessage = geocodingAPI.CheckZip(address,city,zip);
            if (String.IsNullOrEmpty(errorMessage))
                return Json(true);
            else
                return Json(errorMessage);
        }

        // GET: Store/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = storeService.FindById(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
        

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Store store = storeService.FindById(id);
            storeService.Delete(store);
            return RedirectToAction("Index");
        }

    }
}
