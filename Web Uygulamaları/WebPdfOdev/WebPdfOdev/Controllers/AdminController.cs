using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPdfOdev.Models;

namespace WebPdfOdev.Controllers
{

    public class AdminController : Controller
    {
        private PdfWeb db = new PdfWeb();
    

       
        public ActionResult Index()
        {
            return View();
        }
       
     
        public ActionResult OgretmenGoster()//Sadece Ögretmenlerin oldugu tabloyu gösterir
        {
            var res = db.Uye.Where(x => x.yetkiİd == 1).ToList();
            return View(res);
        }
        public ActionResult OgretmenEkle()
        {
            
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult OgretmenEkle(Uye uye)
        {
            var ogretmen = db.Uye.Where(x => x.Kullanaciadi == uye.Kullanaciadi || x.Email == uye.Email).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if(ogretmen==null)
                {
                    uye.yetkiİd = 1;
                    db.Uye.Add(uye);
                    db.SaveChanges();
                    return RedirectToAction("OgretmenGoster");

                }
                else
                {
                    ViewBag.mesaj = Resources.Mesajlar.ogretmenhata1;
                    return View(uye);
                }
                 
            }

           
            return View(uye);
        }
        public ActionResult OgretmenDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
           
            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgretmenDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                uye.yetkiİd = 1;
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OgretmenGoster");
            }
           
            return View(uye);
        }
        public ActionResult OgretmenSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        
        [HttpPost, ActionName("OgretmenSil")]
        [ValidateAntiForgeryToken]
        public ActionResult OgretmenSilConfirmed(int id)
        {
            Uye uye = db.Uye.Find(id);
            db.Uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("OgretmenGoster");
        }

        public ActionResult OgrenciGoster()//Ögrencileri Gösterir SADECE
        {
            var res = db.Uye.Where(x => x.yetkiİd == 2).ToList();
            return View(res);
        }
        public ActionResult OgrenciEkle()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgrenciEkle(Uye uye)
        {
            var ogrenci = db.Uye.Where(x => x.Kullanaciadi == uye.Kullanaciadi ||x.Email == uye.Email).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (ogrenci == null)
                {
                    uye.yetkiİd = 2;
                    db.Uye.Add(uye);
                    db.SaveChanges();
                    return RedirectToAction("OgrenciGoster");

                }
                ViewBag.mesaj = Resources.Mesajlar.ogretmenhata1;
                return View(uye);
            }
            return View();
          

           
        }
        public ActionResult OgrenciSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: Uyes/Delete/5
        [HttpPost, ActionName("OgrenciSil")]
        [ValidateAntiForgeryToken]
        public ActionResult OgrenciSilConfirmed(int id)
        {
            Uye uye = db.Uye.Find(id);
            db.Uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("OgrenciGoster");
        }
        public ActionResult OgrenciDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
          
            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgrenciDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                uye.yetkiİd = 2;
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OgrenciGoster");
            }
            
            return View(uye);
        }
        public ActionResult AdminGoster()
        {
            var res = db.Uye.Where(x => x.yetkiİd == 3).ToList();
            return View(res);

           
        }
        public ActionResult AdminEkle()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEkle(Uye uye)
        {
            var ogrenci = db.Uye.Where(x => x.Kullanaciadi == uye.Kullanaciadi || x.Email == uye.Email).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (ogrenci == null)
                {
                    uye.yetkiİd = 3;
                    db.Uye.Add(uye);
                    db.SaveChanges();
                    return RedirectToAction("AdminGoster");

                }
                ViewBag.mesaj = Resources.Mesajlar.ogretmenhata1;
                return View(uye);
            }
            return View();
        }
        public ActionResult AdminSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: Uyes/Delete/5
        [HttpPost, ActionName("AdminSil")]
        [ValidateAntiForgeryToken]
        public ActionResult AdminSilConfirmed(int id)
        {
            Uye uye = db.Uye.Find(id);
            db.Uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("AdminGoster");
        }
        public ActionResult AdminDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }

            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminDuzenle(Uye uye)
        {
            if (ModelState.IsValid)
            {
                uye.yetkiİd = 3;
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminGoster");
            }

            return View(uye);
        }
        public ActionResult DuyuruGoster()
        {
            return View(db.Duyurular.ToList());
        }
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruEkle([Bind(Include = "duyuruid,duyuruadi,duyuruAciklama,duyuruTarihi")] Duyurular duyurular)
        {
            if (ModelState.IsValid)
            {
                db.Duyurular.Add(duyurular);
                db.SaveChanges();
                return RedirectToAction("DuyuruGoster");
            }

            return View(duyurular);
        }
        
        public ActionResult DuyuruDuzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruDuzenle([Bind(Include = "duyuruid,duyuruadi,duyuruAciklama,duyuruTarihi")] Duyurular duyurular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duyurular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DuyuruGoster");
            }
            return View(duyurular);
        }
        public ActionResult DuyuruSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // POST: Duyurulars/Delete/5
        [HttpPost, ActionName("DuyuruSil")]
        [ValidateAntiForgeryToken]
        public ActionResult DuyuruSilConfirmed(int id)
        {
            Duyurular duyurular = db.Duyurular.Find(id);
            db.Duyurular.Remove(duyurular);
            db.SaveChanges();
            return RedirectToAction("DuyuruGoster");
        }
      
       
        public ActionResult DosyaEkle()
        {
            return View();
        }
      [HttpPost]
          public ActionResult DosyaEkle(HttpPostedFileBase file,PdfDokuman pdf)
           {
            if (ModelState.IsValid)
            {

                try
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Dokuman"), fileName);
                        pdf.pdfYolu = path;
                        file.SaveAs(path);

                        db.PdfDokuman.Add(pdf);
                        db.SaveChanges();
                    }
                    ViewBag.mesaj = Resources.Mesajlar.dosyabasariylaeklendi;
                    return RedirectToAction("PdfEkle");


                }
                catch (Exception ex)
                {
                    ViewBag.mesaj = Resources.Mesajlar.dosyayüklenemedi;
                    return RedirectToAction("PdfEkle");
                }
            }
            else
            {
                ViewBag.mesaj = Resources.Mesajlar.hataolustu;
            }
            return View();
           

        }
        public ActionResult DosyaGoruntule()
        {
            return View(db.PdfDokuman.ToList());
        }
        public ActionResult DosyaDüzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdfDokuman pdfDokuman = db.PdfDokuman.Find(id);
            if (pdfDokuman == null)
            {
                return HttpNotFound();
            }
            return View(pdfDokuman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DosyaDüzenle([Bind(Include = "ıd,pdfAdi,pdfAciklama,pdfKonusu,pdfTarihi,pdfGonderenKisi,pdfYolu")] PdfDokuman pdfDokuman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdfDokuman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PdfGoruntule");
            }
            return View(pdfDokuman);
        }
        public ActionResult DosyaSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdfDokuman pdfDokuman = db.PdfDokuman.Find(id);
            if (pdfDokuman == null)
            {
                return HttpNotFound();
            }
            return View(pdfDokuman);
        }

        // POST: PdfDokumen/Delete/5
        [HttpPost, ActionName("DosyaSil")]
        [ValidateAntiForgeryToken]
        public ActionResult DosyaSilConfirmed(int id)
        {
            PdfDokuman pdfDokuman = db.PdfDokuman.Find(id);
            db.PdfDokuman.Remove(pdfDokuman);
            db.SaveChanges();
            return RedirectToAction("PdfGoruntule");
        }

        public ActionResult Cikis()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Anasayfa", "Home");
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