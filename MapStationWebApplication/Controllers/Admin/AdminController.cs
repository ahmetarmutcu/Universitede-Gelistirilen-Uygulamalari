using StationShowApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StationShowApplication.Controllers.Admin
{
    public class AdminController : Controller
    {
        private StationDb db = new StationDb();
        // GET: Admin
        public ActionResult AdminIndex()
        {
            if(Session["userName"]!=null)
                return View();
            else
            {
                return RedirectToAction("HomeIndex", "Home");
            }
        }
        // GET: Login
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(User uye)
        {
            if (ModelState.IsValid)
            {
                var admin = db.User.FirstOrDefault(u => u.userName == uye.userName && u.userPassword == uye.userPassword && u.userRoleId == 30);
                if (admin != null)
                {
                    Session["userName"] = admin;
                    return RedirectToAction("AdminIndex", "Admin");
                }
               else
                 ViewData["Message"] = "Geçersiz kullanıcı adı veya şifre";
            }
            else
                ViewData["Message"] = "Geçersiz kullanıcı adı veya şifre";


            return View(uye);
        }
        public ActionResult Logout()
        {
            Session["userName"] = null;
            return RedirectToAction("HomeIndex", "Home");

        }

        public ActionResult UserList()
        {
            var user = db.User.Include(u => u.Role);
            return View(user.ToList());
        }


        // GET: Users/Create
        public ActionResult UserCreate()
        {
            ViewBag.userRoleId = new SelectList(db.Role, "roleId", "roleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate([Bind(Include = "userId,name,surname,userName,userPassword,userRoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                user.userCreateDate = DateTime.Now;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            ViewBag.userRoleId = new SelectList(db.Role, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult UserEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.userRoleId = new SelectList(db.Role, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([Bind(Include = "userId,name,surname,userName,userPassword,userCreateDate,userRoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            ViewBag.userRoleId = new SelectList(db.Role, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult UserDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }


        /// <summary>
        /// Point Türü işlemleri
        /// </summary>
        /// <returns></returns>
        // GET: StationTypes
        public ActionResult PointTypeList()
        {
            return View(db.StationType.ToList());
        }

        // GET: StationTypes/Create
        public ActionResult PointTypeCreate()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PointTypeCreate([Bind(Include = "stationTypeId,stationTypeName,stationIconUrl")] StationType stationType)
        {
            if (ModelState.IsValid)
            {
                db.StationType.Add(stationType);
                db.SaveChanges();
                return RedirectToAction("PointTypeList");
            }

            return View(stationType);
        }

        // GET: StationTypes/Edit/5
        public ActionResult PointTypeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationType stationType = db.StationType.Find(id);
            if (stationType == null)
            {
                return HttpNotFound();
            }
            return View(stationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PointTypeEdit([Bind(Include = "stationTypeId,stationTypeName")] StationType stationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PointTypeList");
            }
            return View(stationType);
        }

        // GET: StationTypes/Delete/5
        public ActionResult PointTypeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationType stationType = db.StationType.Find(id);
            if (stationType == null)
            {
                return HttpNotFound();
            }
            return View(stationType);
        }

        // POST: StationTypes/Delete/5
        [HttpPost, ActionName("PointTypeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPointType(int id)
        {
            StationType stationType = db.StationType.Find(id);
            db.StationType.Remove(stationType);
            db.SaveChanges();
            return RedirectToAction("PointTypeList");
        }

        public ActionResult PointDataBotUpdate() {

            return View();
        }
        public ActionResult PointFuelPriceBotUpdate()
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