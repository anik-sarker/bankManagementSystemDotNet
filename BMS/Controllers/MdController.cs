using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BMS.Models;

namespace BMS.Controllers
{
    public class MdController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Md
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUnauthTran()
        {
            var mangrTransections = db.MangrTransections.Include(m => m.Branch).Where(c=>c.Authorized==false);

            return View(mangrTransections.ToList());

        }

        public ActionResult EditTran(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MangrTransection mangrTransection = db.MangrTransections.Find(id);
            if (mangrTransection == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", mangrTransection.BranchId);
            return View(mangrTransection);
        }

        // POST: MangrTransections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTran([Bind(Include = "Id,BranchId,Amount,TransDate")] MangrTransection mangrTransection)
        {
            if (ModelState.IsValid)
            {
                MangrTransection m1 = db.MangrTransections.Find(mangrTransection.Id);
                m1.Authorized = true;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", mangrTransection.BranchId);
            return View(mangrTransection);
        }

    }
}