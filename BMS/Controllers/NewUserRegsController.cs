using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BMS.Models;

namespace BMS.Controllers
{
    public class NewUserRegsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewUserRegs
        public ActionResult Index()
        {
            var newUserRegs = db.NewUserRegs.Include(n => n.UserType);
            return View(newUserRegs.ToList());
        }

        // GET: NewUserRegs/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserTypeId")] NewUserReg newUserReg)
        {
            if (ModelState.IsValid)
            {
                db.NewUserRegs.Add(newUserReg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "Type", newUserReg.UserTypeId);
            return View(newUserReg);
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
