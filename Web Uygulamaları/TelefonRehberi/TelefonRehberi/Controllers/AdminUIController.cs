using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using WebPdfOdev.Filters;

namespace TelefonRehberi.Controllers
{
   
    public class AdminUIController : Controller
    {
        Telefon db = new Telefon();
        // GET: AdminUI
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Calisanlar calisan)
        {
            var admin = db.Calisanlar.Where(u => u.KullaniciAdi == calisan.KullaniciAdi  && u.Sifre == calisan.Sifre).SingleOrDefault();

            if (admin != null)
            {
                if (admin.Yoneticiid == 2)
                {
                    Session["uyeid"] = admin.id;
                    Session["Kullanici"] = admin.KullaniciAdi;
                    Session["yoneticiid"] = admin.Yoneticiid;
                    Session["departmanid"]=admin.Departmanid;
                    
                    return RedirectToAction("Admin", "AdminUI");
                }
                else
                {


                    ViewBag.mesaj ="Böyle bir admin bulunmuyor";
                    return View(calisan);

                }
            }
            else
            {
                ViewBag.mesaj = "Böyle bir admin bulunmuyor";
                return View();
            }
        }
        [AdminAuthorizationFilter]
        public ActionResult Admin()
        {
            return View();
        }
        [AdminAuthorizationFilter]
        public ActionResult YeniCalisanEkle()
        {
            ViewBag.Departmanid = new SelectList(db.Departman, "departmanıd", "departmanadi");
            ViewBag.Yoneticiid = new SelectList(db.Yonetici, "yoneticiid", "yonetici1");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorizationFilter]
        public ActionResult YeniCalisanEkle([Bind(Include = "id,Adi,Soyadi,email,Telefon,KullaniciAdi,Sifre,Departmanid,Yoneticiid")] Calisanlar calisanlar)
        {
            if (ModelState.IsValid)
            {
                db.Calisanlar.Add(calisanlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departmanid = new SelectList(db.Departman, "departmanıd", "departmanadi", calisanlar.Departmanid);
            ViewBag.Yoneticiid = new SelectList(db.Yonetici, "yoneticiid", "yonetici1", calisanlar.Yoneticiid);
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        public ActionResult Index()

        {
            var calisanlar = db.Calisanlar.Where(x => x.Yoneticiid == 1);
            return View(calisanlar.ToList());
        }
        [AdminAuthorizationFilter]
        public ActionResult Detaylar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return HttpNotFound();
            }
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Departmanid = new SelectList(db.Departman, "departmanıd", "departmanadi", calisanlar.Departmanid);
            ViewBag.Yoneticiid = new SelectList(db.Yonetici, "yoneticiid", "yonetici1", calisanlar.Yoneticiid);
            return View(calisanlar);
        }

        [HttpPost]
        [AdminAuthorizationFilter]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "id,Adi,Soyadi,email,Telefon,KullaniciAdi,Sifre,Departmanid,Yoneticiid")] Calisanlar calisanlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calisanlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departmanid = new SelectList(db.Departman, "departmanıd", "departmanadi", calisanlar.Departmanid);
            ViewBag.Yoneticiid = new SelectList(db.Yonetici, "yoneticiid", "yonetici1", calisanlar.Yoneticiid);
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return HttpNotFound();
            }
           
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
           
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            db.Calisanlar.Remove(calisanlar);
            db.SaveChanges();
            return RedirectToAction("Index");
           
           
        }
        [AdminAuthorizationFilter]
        public ActionResult AdminAyarlari(int? id)
        {
            int adminid = Convert.ToInt32(Session["uyeid"]);
            id = adminid;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calisanlar calisanlar = db.Calisanlar.Find(id);
            if (calisanlar == null)
            {
                return HttpNotFound();
            }
          
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminAyarlari(Calisanlar calisanlar)
        {
            if (ModelState.IsValid)
            {
                calisanlar.Departmanid = Convert.ToInt32(Session["departmanid"]);
                calisanlar.Yoneticiid = Convert.ToInt32(Session["yoneticiid"]);
                db.Entry(calisanlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(calisanlar);
        }
        [AdminAuthorizationFilter]
        public ActionResult Cikis()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Anasayfa", "PublicUl");
        }

        
        [AdminAuthorizationFilter]
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