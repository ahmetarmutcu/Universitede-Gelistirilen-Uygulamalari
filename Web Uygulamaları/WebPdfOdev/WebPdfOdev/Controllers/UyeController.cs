using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPdfOdev.Models;
namespace WebPdfOdev.Controllers
{
    public class UyeController : Controller
    {
        PdfWeb db = new PdfWeb();
        // GET: Uye
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OgretmenGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OgretmenGiris(Uye uye)
        {
            var ogretmen = db.Uye.Where(u => u.Kullanaciadi == uye.Kullanaciadi && u.Email == uye.Email && u.Sifre == uye.Sifre).SingleOrDefault();
            
                if (ogretmen!=null)
                {
                     if (ogretmen.yetkiİd == 1)
                {
                    Session["uyeid"] = ogretmen.uyeİd;
                    Session["Kullanici"] = ogretmen.Kullanaciadi;
                    Session["yetkiid"] = ogretmen.yetkiİd;
                    return RedirectToAction("OgretmenAnasayfası", "OgretmenDersler");
                }
                else
                {


                    ViewBag.mesaj = Resources.Mesajlar.ogretmenuye;
                    return View(uye);

                }
                }
                else
                {
                ViewBag.mesaj = Resources.Mesajlar.ogretmenuye;
                return View();
                }
            }

        public ActionResult OgrenciGiris()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult OgrenciGiris(Uye uye)
        {
            var ogrenci = db.Uye.Where(u => u.Kullanaciadi == uye.Kullanaciadi && u.Email == uye.Email&&u.Sifre==uye.Sifre).SingleOrDefault();
          
            if(ogrenci!=null)
            {
                if(ogrenci.yetkiİd == 2)
                  {
                
                    Session["uyeid"] = ogrenci.uyeİd;
                    Session["Kullanici"] = ogrenci.Kullanaciadi;
                    Session["yetkiid"] = ogrenci.yetkiİd;
                    return RedirectToAction("OgrenciAnasayfa", "OgrenciSayfasi");
                
              
                    }
                 else
                    {
                ViewBag.mesaj = Resources.Mesajlar.ogrenciuye;
                return View(uye);
                 }
            }
            ViewBag.mesaj = Resources.Mesajlar.ogrenciuyehata;
            return View(uye);
        }
        public ActionResult AdminGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiris(Uye uye)
        {
           
            var admin = db.Uye.Where(u => u.Kullanaciadi == uye.Kullanaciadi && u.Sifre==uye.Sifre).SingleOrDefault();

            if (admin!=null)
            {
                if (admin.yetkiİd == 3)
                {
                    Session["uyeid"] = admin.uyeİd;
                    Session["Kullanici"] = admin.Kullanaciadi;
                    Session["yetkiid"] = admin.yetkiİd;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {

                    ViewBag.mesaj = Resources.Mesajlar.adminüye;
                    return View(uye);

                }
            }
            else
            {
                ViewBag.mesaj = Resources.Mesajlar.adminüye;
                return View(uye);
            }
           
        }



        public ActionResult Cikis()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("Anasayfa","Home");
        }
        public ActionResult UyeOlustur()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult UyeOlustur(Uye uye)
        {
            if(ModelState.IsValid)
            {
                var kullanicikontrol = db.Uye.Where(x => x.Kullanaciadi == uye.Kullanaciadi||x.Email==uye.Email).FirstOrDefault();
                if(kullanicikontrol==null)
                {
                    if (Convert.ToString(uye.yetkiİd) == "1")
                    {
                        db.Uye.Add(uye);
                        db.SaveChanges();
                        Session["uyeid"] = uye.uyeİd;
                        Session["Kullanici"] = uye.Kullanaciadi;
                        ViewBag.mesaj = "ÖgretmenPdf üyesi oldunuz";
                        return RedirectToAction("OgretmenGiris", "Uye");
                    }
                    if (Convert.ToString(uye.yetkiİd) == "2")
                    {
                        db.Uye.Add(uye);
                        db.SaveChanges();
                        Session["uyeid"] = uye.uyeİd;
                        Session["Kullanici"] = uye.Kullanaciadi;
                        ViewBag.mesaj = "ÖgrenciPdf üyesi oldunuz";
                        return RedirectToAction("OgrenciGiris", "Uye");
                        
                    }
                }
                else
                {
                    ViewBag.mesaj = Resources.Mesajlar.emailzatenvar;
                }

                
            }
           
                ViewBag.mesaj = Resources.Mesajlar.hataolustu;
           
            return View(uye);
        }
        public ActionResult HataSayfasi()
        {
            return View();
                }


    }
}