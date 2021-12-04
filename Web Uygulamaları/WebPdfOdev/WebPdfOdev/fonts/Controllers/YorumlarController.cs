using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPdfOdev.Models;

namespace WebPdfOdev.Controllers
{
    public class YorumlarController : Controller
    {
        private PdfWeb db = new PdfWeb();
      
        public ActionResult ZiyaretciYorumları()
        {

            var res = db.ZiyaretciYorumu.ToList();
            return View(res);
        }
        public ActionResult ZiyaretciDetayları(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZiyaretciYorumu ziyaretciYorumu = db.ZiyaretciYorumu.Find(id);
            if (ziyaretciYorumu == null)
            {
                return HttpNotFound();
            }
            return View(ziyaretciYorumu);
        }
        public ActionResult ZiyaretciSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZiyaretciYorumu ziyaretciYorumu = db.ZiyaretciYorumu.Find(id);
            if (ziyaretciYorumu == null)
            {
                return HttpNotFound();
            }
            return View(ziyaretciYorumu);
        }

        // POST: ZiyaretciYorumus/Sil/5
        [HttpPost, ActionName("ZiyaretciSil")]
        [ValidateAntiForgeryToken]
        public ActionResult ZiyaretciSilConfirmed(int id)
        {
            ZiyaretciYorumu ziyaretciYorumu = db.ZiyaretciYorumu.Find(id);
            db.ZiyaretciYorumu.Remove(ziyaretciYorumu);
            db.SaveChanges();
            return RedirectToAction("ZiyaretciYorumları");
        }
        public ActionResult OgretmenAdminYorum()
        {
            return View();
        }

        public ActionResult AdminYorumYap(string yorum)
        {

            var uyeid = Session["uyeid"];
            var uyeyetkiid = Session["yetkiid"];
            var uyekullanici = Session["Kullanici"];
            if (yorum != null)
            {
                db.Yorum.Add(new Yorum { Uyeid = Convert.ToInt32(uyeid), UyeYetki = Convert.ToInt32(uyeyetkiid), uyeEmail = uyekullanici.ToString(), icerik = yorum, Tarihi = DateTime.Now });
                db.SaveChanges();
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OgrenciAdminYorum()
        {
            return View();
        }
       

    }
}