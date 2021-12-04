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
    public class OgretmenAdminİletisimController : Controller
    {
        private PdfWeb db = new PdfWeb();

        // GET: Yorums
        public ActionResult YorumlariGör()
        {
            var res = db.Yorum.Where(x => x.UyeYetki==1).ToList();
            return View(res);
            /*var yorum = db.Yorum.Include(y => y.Uye).Include(y => y.Yetkisi);
            return View(yorum.ToList());
            */
        }

        // GET: Yorums/Details/5
        public ActionResult YorumDetay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

     

        // GET: Yorums/Delete/5
        public ActionResult YorumSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorum.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("YorumSil")]
        [ValidateAntiForgeryToken]
        public ActionResult YorumSilConfirmed(int id)
        {
            Yorum yorum = db.Yorum.Find(id);
            db.Yorum.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("YorumlariGör");
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
