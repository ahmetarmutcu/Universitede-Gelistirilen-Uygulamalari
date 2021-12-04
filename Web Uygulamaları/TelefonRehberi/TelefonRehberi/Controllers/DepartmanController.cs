using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using WebPdfOdev.Filters;

namespace TelefonRehberi.Controllers
{
    [AdminAuthorizationFilter]
    public class DepartmanController : Controller
    {
        private Telefon db = new Telefon();

        // GET: Departman
        public ActionResult Index()
        {
            return View(db.Departman.ToList());
        }

        
        public ActionResult Detaylar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            var departmancalisanlari = db.Calisanlar.Where(x => x.Departmanid == id).ToList();
            return View(departmancalisanlari);
        }

        // GET: Departman/Create
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DepartmanEkle([Bind(Include = "departmanıd,departmanadi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Departman.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departman);
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "departmanıd,departmanadi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult SilConfirmed(int id)
        {
            var kontrol = db.Calisanlar.Where(x => x.Departmanid == id).FirstOrDefault();
            if(kontrol!=null)
            {
                return RedirectToAction("DepartmanHata");
                
            }
            Departman departman = db.Departman.Find(id);
            db.Departman.Remove(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanHata()
        {
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
