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
    public class TBL_SEHIRDISITURController : Controller
    {
        private veritabani db = new veritabani();

        // GET: TBL_SEHIRDISITUR
        public ActionResult Goster()
        {
            var tBL_SEHIRDISITUR = db.TBL_SEHIRDISITUR.Include(t => t.TBL_ILADLARI);
            return View(tBL_SEHIRDISITUR.ToList());
        }
        

        public ActionResult Ekle()
        {
            ViewBag.il_id = new SelectList(db.TBL_ILADLARI, "il_id", "il_adi");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "id,baslik,slider_bilgi,slider_resim,il_id")] TBL_SEHIRDISITUR tBL_SEHIRDISITUR, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_SEHIRDISITUR.slider_resim = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.TBL_SEHIRDISITUR.Add(tBL_SEHIRDISITUR);
                db.SaveChanges();
                return RedirectToAction("Goster");
            }

            ViewBag.il_id = new SelectList(db.TBL_ILADLARI, "il_id", "il_adi", tBL_SEHIRDISITUR.il_id);
            return View(tBL_SEHIRDISITUR);
        }

        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SEHIRDISITUR tBL_SEHIRDISITUR = db.TBL_SEHIRDISITUR.Find(id);
            if (tBL_SEHIRDISITUR == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SEHIRDISITUR);
        }

        // POST: TBL_SEHIRDISITUR/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {

            TBL_SEHIRDISITUR tBL_SEHIRDISITUR = db.TBL_SEHIRDISITUR.Find(id);
            db.TBL_SEHIRDISITUR.Remove(tBL_SEHIRDISITUR);
            if (System.IO.File.Exists(Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/") + tBL_SEHIRDISITUR.slider_resim))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/") + tBL_SEHIRDISITUR.slider_resim);
            }
            db.SaveChanges();
            return RedirectToAction("Goster");
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
