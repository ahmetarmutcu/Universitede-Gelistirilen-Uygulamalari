using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using System.Data.Entity;
using System.Net;

namespace TelefonRehberi.Controllers
{
    [AllowAnonymous]
    public class PublicUlController : Controller
    {
        private Telefon db = new Telefon();
        // GET: PublicUl
        public ActionResult Anasayfa()
        {
            var res = db.Calisanlar.ToList();
                return View(res);
           
        }
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
        public ActionResult Hata()
        {
            return View();
        }
    }
}