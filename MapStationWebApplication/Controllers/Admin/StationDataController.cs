using StationShowApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StationShowApplication.Controllers.Admin
{
    public class StationDataController : Controller
    {
        
            private StationDb db = new StationDb();

            // GET: Admin
            public ActionResult List()
            {
                return View(db.DataStation.ToList());
            }

            // GET: Admin/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DataStation dataStation = db.DataStation.Find(id);
                if (dataStation == null)
                {
                    return HttpNotFound();
                }
                return View(dataStation);
            }

            // GET: Admin/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Admin/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "stationId,stationName,stationAdres,stationCity,stationCountry,stationPhone,stationLatX,stationLatY")] DataStation dataStation)
            {
                if (ModelState.IsValid)
                {
                    db.DataStation.Add(dataStation);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }

                return View(dataStation);
            }

            // GET: Admin/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DataStation dataStation = db.DataStation.Find(id);
                if (dataStation == null)
                {
                    return HttpNotFound();
                }
                return View(dataStation);
            }

            // POST: Admin/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "stationId,stationName,stationAdres,stationCity,stationCountry,stationPhone,stationLatX,stationLatY")] DataStation dataStation)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(dataStation).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(dataStation);
            }

            // GET: Admin/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DataStation dataStation = db.DataStation.Find(id);
                if (dataStation == null)
                {
                    return HttpNotFound();
                }
                return View(dataStation);
            }

            // POST: Admin/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                DataStation dataStation = db.DataStation.Find(id);
                db.DataStation.Remove(dataStation);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        public ActionResult StationDataBot()
        {
            return View();
        }
           
    }
}