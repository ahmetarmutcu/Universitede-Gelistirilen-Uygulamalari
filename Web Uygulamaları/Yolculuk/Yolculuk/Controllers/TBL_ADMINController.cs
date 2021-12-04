using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yolculuk.Models;

namespace Yolculuk.Controllers
{
    public class TBL_ADMINController : Controller
    {
        private veritabani db = new veritabani();

        public ActionResult Index()
        {
            return View(db.TBL_ADMIN.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_ADMIN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kullaniciadi,sifre")] TBL_ADMIN tBL_ADMIN)
        {
            if (ModelState.IsValid)
            {
                db.TBL_ADMIN.Add(tBL_ADMIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_ADMIN);
        }

        // GET: TBL_ADMIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ADMIN tBL_ADMIN = db.TBL_ADMIN.Find(id);
            if (tBL_ADMIN == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ADMIN);
        }

        // POST: TBL_ADMIN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kullaniciadi,sifre")] TBL_ADMIN tBL_ADMIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ADMIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_ADMIN);
        }

        // GET: TBL_ADMIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ADMIN tBL_ADMIN = db.TBL_ADMIN.Find(id);
            if (tBL_ADMIN == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ADMIN);
        }

        // POST: TBL_ADMIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_ADMIN tBL_ADMIN = db.TBL_ADMIN.Find(id);
            db.TBL_ADMIN.Remove(tBL_ADMIN);
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
