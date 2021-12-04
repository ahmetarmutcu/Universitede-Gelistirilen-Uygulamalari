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
    public class TBL_ILADLARIController : Controller
    {
        private veritabani db = new veritabani();

        // GET: TBL_ILADLARI
        public ActionResult Goster()
        {
            return View(db.TBL_ILADLARI.ToList());
        }

        // GET: TBL_ILADLARI/Create
        public ActionResult Ekle()
        {
            return View();
        }

        // POST: TBL_ILADLARI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle([Bind(Include = "il_id,il_adi,slider_anaresim")] TBL_ILADLARI tBL_ILADLARI,HttpPostedFileBase file)
        {
            if (file != null)
            {
                string resimadi = System.IO.Path.GetFileName(file.FileName);
                string resimyolu = Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/Anaresimler/" + resimadi);
                file.SaveAs(resimyolu);
                tBL_ILADLARI.slider_anaresim = resimadi;
            }
            if (ModelState.IsValid)
            {
                db.TBL_ILADLARI.Add(tBL_ILADLARI);
                db.SaveChanges();
                return RedirectToAction("Goster");
            }

            return View(tBL_ILADLARI);
        }


        // GET: TBL_ILADLARI/Delete/5
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_ILADLARI tBL_ILADLARI = db.TBL_ILADLARI.Find(id);
            if (tBL_ILADLARI == null)
            {
                return HttpNotFound();
            }
            return View(tBL_ILADLARI);
        }

        // POST: TBL_ILADLARI/Delete/5
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
            TBL_ILADLARI tBL_ILADLARI = db.TBL_ILADLARI.Find(id);
            db.TBL_ILADLARI.Remove(tBL_ILADLARI);
            if (System.IO.File.Exists(Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/Anaresimler/") + tBL_ILADLARI.slider_anaresim))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/img/hizmetler/SehirDisiTur/Anaresimler/") + tBL_ILADLARI.slider_anaresim);
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
