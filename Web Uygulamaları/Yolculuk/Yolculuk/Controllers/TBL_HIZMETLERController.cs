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
    public class TBL_HIZMETLERController : Controller
    {
        private veritabani db = new veritabani();

        public ActionResult Hizmetler()
        {
            return View(db.TBL_HIZMETLER.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "id,baslik,resimadi,resimyonlendirme")] TBL_HIZMETLER tBL_HIZMETLER, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/HizmetlerAnasayfa/"+ resimadi);
                file.SaveAs(resimyolu);
                tBL_HIZMETLER.resimadi = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.TBL_HIZMETLER.Add(tBL_HIZMETLER);
                db.SaveChanges();
                return RedirectToAction("Hizmetler");
            }

            return View(tBL_HIZMETLER);
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_HIZMETLER tBL_HIZMETLER = db.TBL_HIZMETLER.Find(id);
            if (tBL_HIZMETLER == null)
            {
                return HttpNotFound();
            }
            return View(tBL_HIZMETLER);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "id,baslik,resimadi,resimyonlendirme")] TBL_HIZMETLER tBL_HIZMETLER, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/HizmetlerAnasayfa/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_HIZMETLER.resimadi = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tBL_HIZMETLER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Hizmetler");
            }
            return View(tBL_HIZMETLER);
        }

        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_HIZMETLER tBL_HIZMETLER = db.TBL_HIZMETLER.Find(id);
            if (tBL_HIZMETLER == null)
            {
                return HttpNotFound();
            }
            return View(tBL_HIZMETLER);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_HIZMETLER tBL_HIZMETLER = db.TBL_HIZMETLER.Find(id);
            db.TBL_HIZMETLER.Remove(tBL_HIZMETLER);
            if (System.IO.File.Exists(Server.MapPath("~/Content/img/hizmetler/HizmetlerAnasayfa/") + tBL_HIZMETLER.resimadi))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/hizmetler/HizmetlerAnasayfa/") + tBL_HIZMETLER.resimadi);
            }
            db.SaveChanges();
            return RedirectToAction("Hizmetler");
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
