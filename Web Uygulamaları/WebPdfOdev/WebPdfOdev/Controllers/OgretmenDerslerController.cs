using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPdfOdev.Models;

namespace WebPdfOdev.Controllers
{
    public class OgretmenDerslerController : Controller
    {
        private PdfWeb db = new PdfWeb();
        public ActionResult OgretmenAnasayfası()
        {
            return View();
        }
        public ActionResult DersleriGöster()
        {
            var uyekullanici = Session["Kullanici"];
            var osdersler = db.OgretmenDersleri.Where(x => x.kullaniciadi == uyekullanici.ToString()).ToList();//Ogrenci kullanıcısını sectigi dersler
            return View(osdersler);
        }
        public ActionResult DersEkle()
        {
           
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DersEkle(OgretmenDersleri ogretmenDersleri)
        {
            var uyekullanici = Session["Kullanici"];
            var uyeid = Session["uyeid"];

            var derskodukontrol = db.OgretmenDersleri.Where(x => x.derskodu == ogretmenDersleri.derskodu && x.kullaniciadi==uyekullanici.ToString()).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (derskodukontrol == null)
                {
                    ogretmenDersleri.kullaniciadi = uyekullanici.ToString();
                    ogretmenDersleri.uyeid = Convert.ToInt32(uyeid);
                    db.OgretmenDersleri.Add(ogretmenDersleri);
                    db.SaveChanges();

                    

                    return RedirectToAction("DersleriGöster");
                }
                
                else
                {
                    ViewBag.mesaj =Resources.Mesajlar.derskoduvarzaten;
                }
                  
                
            }

           
            return View(ogretmenDersleri);
        }
      

        // GET: OgretmenDersler/Delete/5
        public ActionResult DersSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenDersleri ogretmenDersleri = db.OgretmenDersleri.Find(id);
            if (ogretmenDersleri == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenDersleri);
        }

      
        [HttpPost, ActionName("DersSil")]
        [ValidateAntiForgeryToken]
        public ActionResult DersSilConfirmed(int id)
        {
            OgretmenDersleri ogretmenDersleri = db.OgretmenDersleri.Find(id);
            db.OgretmenDersleri.Remove(ogretmenDersleri);
            db.SaveChanges();
            return RedirectToAction("DersleriGöster");
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
