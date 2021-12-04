using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Yolculuk.Models;

namespace Yolculuk.Controllers
{
    public class AyserenController : Controller
    {
        private veritabani db = new veritabani();
        public ActionResult Index(string dilsec)
        {
            if (dilsec != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(dilsec);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(dilsec);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = dilsec;
            Response.Cookies.Add(cookie);
            ViewModel vm = new ViewModel();
            vm.TBL_SLİDER = db.TBL_SLİDER.ToList();
            return View(vm);
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Hizmetlerimiz()
        {
           
            return View(db.TBL_HIZMETLER.ToList());
        }
        public ActionResult IstanbulTuru()
        {
            return View(db.TBL_ISTANBULTURU.ToList());
        }
        public ActionResult SehirDisiTuru()
        {
            ViewModel vm = new ViewModel();
            vm.TBL_SEHIRDISITUR = db.TBL_SEHIRDISITUR.ToList();
            vm.TBL_ILADLARI = db.TBL_ILADLARI.ToList();
            return View(vm);
        }
        public ActionResult Iletisim()
        {
            return View();
        }
       
        public ActionResult DugunHizmetleri()
        {
            return View();
        }
        public ActionResult OzelSoforluTransfer()
        {
            return View();
        }
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiris(TBL_ADMIN uye)
        {
            var admin = db.TBL_ADMIN.Where(u => u.kullaniciadi == uye.kullaniciadi && u.sifre == uye.sifre).SingleOrDefault();
            if (admin != null)
            {
                Session["kullaniciadi"] = admin.kullaniciadi;
                return RedirectToAction("SliderGosterme", "TBL_SLİDER");
            }
            else
            {
                return View(uye);
            }
        }
        public ActionResult Cikis()
        {
            Session["kullaniciadi"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Ayseren");
        }
        public ActionResult HataSayfasi()
        {
            return View();
        }
        public ActionResult SabihaGokcenHavaalani()
        {
            return View();
        }
        public ActionResult AtaturkHavalimani()
        {
            return View();
        }
        public ActionResult YeniHavalimaniTransfer()
        {
            return View();
        }
        public ActionResult BusinessTransfer()
        {
            return View();
        }

    }
}