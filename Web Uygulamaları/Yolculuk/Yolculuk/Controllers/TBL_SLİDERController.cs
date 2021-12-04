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
    public class TBL_SLİDERController : Controller
    {
        private veritabani db = new veritabani();

        // GET: TBL_SLİDER
        public ActionResult SliderGosterme()
        {
            return View(db.TBL_SLİDER.ToList());
        }

        public ActionResult Ekleme()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekleme([Bind(Include = "id,buyuk_baslik,kısa_baslik,resim_yolu")]TBL_SLİDER slider,HttpPostedFileBase file)
        {
            if(file!=null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/slider/" + resimadi);
                file.SaveAs(resimyolu);
                slider.resim_yolu = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.TBL_SLİDER.Add(slider);
                db.SaveChanges();
                return RedirectToAction("SliderGosterme");
            }
            return View(slider);
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SLİDER tBL_SLİDER = db.TBL_SLİDER.Find(id);
            if (tBL_SLİDER == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SLİDER);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "id,buyuk_baslik,kısa_baslik,resim_yolu")] TBL_SLİDER tBL_SLİDER, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/slider/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_SLİDER.resim_yolu = resimadi;
            }
       
            if (ModelState.IsValid)
            {
                db.Entry(tBL_SLİDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SliderGosterme");
            }
            return View(tBL_SLİDER);
        }

        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_SLİDER tBL_SLİDER = db.TBL_SLİDER.Find(id);
            if (tBL_SLİDER == null)
            {
                return HttpNotFound();
            }
            return View(tBL_SLİDER);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
            TBL_SLİDER tBL_SLİDER = db.TBL_SLİDER.Find(id);
            db.TBL_SLİDER.Remove(tBL_SLİDER);
            if (System.IO.File.Exists(Server.MapPath("~/Content/img/slider/") + tBL_SLİDER.resim_yolu))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/slider/") + tBL_SLİDER.resim_yolu);
            }
            db.SaveChanges();
            return RedirectToAction("SliderGosterme");
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
