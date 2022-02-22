using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using WebApplication2.Models;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private RMSDBContext db = new RMSDBContext();

        // GET: Account
        public ActionResult Index()
        {
            using (RMSDBContext db = new RMSDBContext())
            {
                return View(db.Reg_Pages.ToList());
            }
        }

        // GET: Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg_Page reg_Page = db.Reg_Pages.Find(id);
            if (reg_Page == null)
            {
                return HttpNotFound();
            }
            return View(reg_Page);
        }

        // GET: Account/Create
        /*public ActionResult Create()
        {
            return View();
        }*/

        // POST: Account/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fname,Lname,Phone,Email,Password")] reg_Page reg_page)
        {
            if (ModelState.IsValid)
            {
                db.Reg_Pages.Add(reg_page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reg_page);
        }*/

        // GET: Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg_Page reg_page = db.Reg_Pages.Find(id);
            if (reg_page == null)
            {
                return HttpNotFound();
            }
            return View(reg_page);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,F_name,L_name,Phone_no,Email,Username,Password")] reg_Page reg_page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg_page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg_page);
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reg_Page reg_page = db.Reg_Pages.Find(id);
            if (reg_page == null)
            {
                return HttpNotFound();
            }
            return View(reg_page);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            reg_Page reg_page = db.Reg_Pages.Find(id);
            db.Reg_Pages.Remove(reg_page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Registration
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Register(reg_Page account)
        {
            if (ModelState.IsValid)
            {
                using (RMSDBContext db = new RMSDBContext())
                {
                    db.Reg_Pages.Add(account);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(reg_Page user)
        {
            using (RMSDBContext db = new RMSDBContext())
            {
                var usr = db.Reg_Pages.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                } 
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        //Facebook login




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
