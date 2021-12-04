using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPdfOdev.Models;

namespace WebPdfOdev.Controllers
{
    public class HomeController : Controller
    {
        private PdfWeb db = new PdfWeb();
        // GET: Home
        public ActionResult Anasayfa(String LanguageAbbrevation)
        {
            if (LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);
            
            return View(db.Duyurular.ToList());
            
        }
        [AllowAnonymous]
        public ActionResult İletisim()
        {

            return View();

        }
        [AllowAnonymous]
        public ActionResult Hakkimizda()
        {
            return View();
        }
      
        public ActionResult Download()
        {
            var file = db.PdfDokuman.ToList();
            return View(file);
        }

        public FileResult DownloadFile(string id)
        {
            int fid = Convert.ToInt32(id);
            string filename = (from f in db.PdfDokuman
                               where f.ıd == fid
                               select f.pdfYolu).First();
            return File(filename, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }


        [AllowAnonymous]
        public ActionResult ziyaretciYorumAt(string yorum, string email,string adisoyadi)
        {
           
            
            if (yorum != null)
            {
                db.ZiyaretciYorumu.Add(new ZiyaretciYorumu {ziyaretciAdi=adisoyadi,ziyaretciEmail=email, İcerik = yorum, Tarih = DateTime.Now });
                db.SaveChanges();
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}
   

   
  
