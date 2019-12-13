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
    public class MangrTransectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MangrTransections
        public ActionResult Index()
        {
            var mangrTransections = db.MangrTransections.Include(m => m.Branch);
            return View(mangrTransections.ToList());
        }

        // GET: MangrTransections/Details/5
        public ActionResult Details(int? id)
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
            return View(mangrTransection);
        }

        // GET: MangrTransections/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: MangrTransections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BranchId,Amount,TransDate")] MangrTransection mangrTransection)
        {
            if (ModelState.IsValid)
            {

                db.MangrTransections.Add(mangrTransection);
                db.SaveChanges();

                Branch b1= new Branch();
                
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", mangrTransection.BranchId);
            return View(mangrTransection);
        }

        // GET: MangrTransections/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "Id,BranchId,Amount,TransDate")] MangrTransection mangrTransection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mangrTransection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", mangrTransection.BranchId);
            return View(mangrTransection);
        }

        // GET: MangrTransections/Delete/5
        public ActionResult Delete(int? id)
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
            return View(mangrTransection);
        }

        // POST: MangrTransections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MangrTransection mangrTransection = db.MangrTransections.Find(id);
            db.MangrTransections.Remove(mangrTransection);
            db.SaveChanges();
            return RedirectToAction("Index");
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
