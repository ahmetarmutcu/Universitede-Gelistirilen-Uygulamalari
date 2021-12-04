using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPdfOdev.Models;

namespace WebPdfOdev.Controllers
{
    public class DosyaYonetimController : Controller
    {
        private PdfWeb db = new PdfWeb();
       
        public ActionResult DosyaEklenecekDersler()
        {
            var uyekullanici = Session["Kullanici"];
            var secilmisdersler = db.OgretmenDersleri.Where(x => x.kullaniciadi == uyekullanici.ToString()).ToList();
            
            return View(secilmisdersler);
        }

        public ActionResult DosyaEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DosyaEkle(PdfModel pdfModel, HttpPostedFileBase file)
        {


            var uyekullanici = Session["Kullanici"];
            var uyeid = Session["uyeid"];
            

            if (ModelState.IsValid)
            {
                
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                        pdfModel.pdfYolu = path;
                        
                        file.SaveAs(path);
                        pdfModel.pdfKullanici = uyekullanici.ToString();
                        pdfModel.pdfuyeid = Convert.ToInt32(uyeid);
                        pdfModel.pdfTarihi = DateTime.Now;
                        pdfModel.pdfDerskodu = Session["derskodu"].ToString();

                         db.PdfModel.Add(pdfModel);
                        db.SaveChanges();
                    ViewBag.mesaj = Resources.Döküman.AdminDokuman.degişiklikbutton;
                    return RedirectToAction("DosyaEkle");

                }
              

             }
            return View();
              
         }
         public ActionResult OgretmenDosyalari()
        {
            var uyekullanici = Session["Kullanici"];
            var ogretmenpdf = db.PdfModel.Where(x => x.pdfKullanici == uyekullanici.ToString()).ToList();
            return View(ogretmenpdf);
        }
        public ActionResult OgretmenDosyaDüzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdfModel pdfModel = db.PdfModel.Find(id);
            if (pdfModel == null)
            {
                return HttpNotFound();
            }
            return View(pdfModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgretmenDosyaDüzenle([Bind(Include = "ıd,pdfAdi,pdfYolu,pdfAciklama")] PdfModel pdfModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdfModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OgretmenDosyalari");
            }
            return View(pdfModel);
        }
        public ActionResult OgretmenDosyaSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdfModel pdfModel = db.PdfModel.Find(id);
            if (pdfModel == null)
            {
                return HttpNotFound();
            }
            return View(pdfModel);
        }

        [HttpPost, ActionName("OgretmenDosyaSil")]
        [ValidateAntiForgeryToken]
        public ActionResult OgretmenDosyaSilConfirmed(int id)
        {
            PdfModel pdfModel = db.PdfModel.Find(id);
            db.PdfModel.Remove(pdfModel);
        
            if (System.IO.File.Exists(Server.MapPath("~/Content/Uploads")+pdfModel.pdfAdi))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Uploads") + pdfModel.pdfAdi);
            }
            db.SaveChanges();
            return RedirectToAction("OgretmenDosyalari");
        }

        public ActionResult DokumanlarDosyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DokumanlarDosyaEkle(HttpPostedFileBase file, PdfDokuman pdf)
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
                    return RedirectToAction("DokumanlarDosyaEkle");


                }
                catch (Exception ex)
                {
                    ViewBag.mesaj = Resources.Mesajlar.dosyayüklenemedi;
                    return RedirectToAction("DokumanlarDosyaEkle");
                }
            }
            else
            {
                ViewBag.mesaj = Resources.Mesajlar.dosyaekleyemedinizbazıhatalardandolayı;
            }
            return View();


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
