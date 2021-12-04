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
    public class TBL_ISTANBULTURUController : Controller
    {
        private veritabani db = new veritabani();

        public ActionResult IstanbulTuru()
        {
            return View(db.TBL_ISTANBULTURU.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "id,baslik,resimadi")] TBL_ISTANBULTURU tBL_ISTANBULTURU, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/SehirTuru/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_ISTANBULTURU.resimadi = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.TBL_ISTANBULTURU.Add(tBL_ISTANBULTURU);
                db.SaveChanges();
                return RedirectToAction("IstanbulTuru");
            }

            return View(tBL_ISTANBULTURU);
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ISTANBULTURU tBL_ISTANBULTURU = db.TBL_ISTANBULTURU.Find(id);
            if (tBL_ISTANBULTURU == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ISTANBULTURU);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "id,baslik,resimadi")] TBL_ISTANBULTURU tBL_ISTANBULTURU, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/SehirTuru/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_ISTANBULTURU.resimadi = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tBL_ISTANBULTURU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IstanbulTuru");
            }
            return View(tBL_ISTANBULTURU);
        }

        // GET: TBL_ISTANBULTURU/Delete/5
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ISTANBULTURU tBL_ISTANBULTURU = db.TBL_ISTANBULTURU.Find(id);
            if (tBL_ISTANBULTURU == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ISTANBULTURU);
        }

        // POST: TBL_ISTANBULTURU/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
            TBL_ISTANBULTURU tBL_ISTANBULTURU = db.TBL_ISTANBULTURU.Find(id);
            db.TBL_ISTANBULTURU.Remove(tBL_ISTANBULTURU);
            if (System.IO.File.Exists(Server.MapPath("~/Content/img/hizmetler/SehirTuru/") + tBL_ISTANBULTURU.resimadi))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/hizmetler/SehirTuru/") + tBL_ISTANBULTURU.resimadi);
            }
            db.SaveChanges();
            return RedirectToAction("IstanbulTuru");
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
