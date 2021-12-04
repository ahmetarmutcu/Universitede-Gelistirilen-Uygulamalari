using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPdfOdev.Models;
using PagedList;
using PagedList.Mvc;

namespace WebPdfOdev.Controllers
{
    public class OgrenciSayfasiController : Controller
    {
        PdfWeb db = new PdfWeb();
       
        public ActionResult OgrenciAnasayfa()
        {
            return View();
        }
        public ActionResult DersKoduGir()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult  DersKoduGir(string pdfDerskodu, string pdfKullanici)
        {
            Session["derskodu"] = pdfDerskodu;
            Session["kullanici"] = pdfKullanici;
            var derskodukontrol = db.PdfModel.Where(x => x.pdfDerskodu == pdfDerskodu && x.pdfKullanici == pdfKullanici).FirstOrDefault();
            if(derskodukontrol!=null)
            {
                return RedirectToAction("SecilenDersler");
            }
           else
            {
                ViewBag.mesaj = Resources.Mesajlar.derskoduvekullanıcıyoktur;
            }
            return View();


        }

        public ActionResult SecilenDersler()
        {
            var a1 = Session["derskodu"].ToString();
            var b1 = Session["kullanici"].ToString();
            var abc = db.PdfModel.Where(x => x.pdfDerskodu == a1 && x.pdfKullanici == b1);
            return View(abc.ToList());
            


        }
        public ActionResult Download()
        {
            var file = db.PdfModel.ToList();
            return View(file);
        }

        public FileResult DownloadFile(string id)
        {
            int fid = Convert.ToInt32(id);
            string filename = (from f in db.PdfModel
                               where f.ıd == fid
                               select f.pdfYolu).First();
            return File(filename, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }






    }
}