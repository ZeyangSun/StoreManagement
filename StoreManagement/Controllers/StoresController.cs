using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Models;
using Velyo.Google.Services;
using Velyo.Google.Services.Models;

namespace StoreManagement.Controllers
{
    public class StoresController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Stores
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Company);
            return View(stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> CreateAsync([Bind(Include = "Id,CompanyId,Name,Address,City,Zip,Country,Longitude,Latitude")] Store store)
        {
            if (ModelState.IsValid)
            {   
                store.Id = Guid.NewGuid();
                GeocodingRequest request = new GeocodingRequest(store.Address +" "+ store.City);//store.Address+store.City
                request.IsSensor = false;
                GeocodingResponse response = await request.GetResponseAsync();
                var result = response.Results.First();
                
                LatLng location = result.Geometry.Location;
                double latitude = location.Latitude;
                double longitude = location.Longitude;
                System.Diagnostics.Debug.WriteLine("---------------  " + latitude);
                System.Diagnostics.Debug.WriteLine("+++++++++++  " + longitude);
                store.Longitude = longitude.ToString();
                store.Latitude = latitude.ToString();
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> EditAsync([Bind(Include = "Id,CompanyId,Name,Address,City,Zip,Country,Longitude,Latitude")] Store store)
        {
            if (ModelState.IsValid)
            {
                GeocodingRequest request = new GeocodingRequest(store.Address + " " + store.City);//store.Address+store.City
                request.IsSensor = false;
                GeocodingResponse response = await request.GetResponseAsync();
                var result = response.Results.First();

                LatLng location = result.Geometry.Location;
                double latitude = location.Latitude;
                double longitude = location.Longitude;
                System.Diagnostics.Debug.WriteLine("---------------  " + latitude);
                System.Diagnostics.Debug.WriteLine("+++++++++++  " + longitude);
                store.Longitude = longitude.ToString();
                store.Latitude = latitude.ToString();
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", store.CompanyId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
