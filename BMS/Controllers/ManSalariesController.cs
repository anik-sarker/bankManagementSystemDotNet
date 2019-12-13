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
    public class ManSalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManSalaries
        public ActionResult Index()
        {
            var manSalaries = db.ManSalaries.Include(m => m.Manager);
            return View(manSalaries.ToList());
        }

        // GET: ManSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return HttpNotFound();
            }
            return View(manSalary);
        }

        // GET: ManSalaries/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "Name");
            return View();
        }

        // POST: ManSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ManagerId,SalaryAmn,Date")] ManSalary manSalary)
        {
            if (ModelState.IsValid)
            {
               Manager m1 = db.Managers.Find(manSalary.ManagerId);
               m1.Salary = m1.Salary + manSalary.SalaryAmn;

               db.ManSalaries.Add(manSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "Name", manSalary.ManagerId);
            return View(manSalary);
        }

        // GET: ManSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "Name", manSalary.ManagerId);
            return View(manSalary);
        }

        // POST: ManSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ManagerId,SalaryAmn,Date")] ManSalary manSalary)
        {
            if (ModelState.IsValid)
            {

                db.Entry(manSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "Name", manSalary.ManagerId);
            return View(manSalary);
        }

        // GET: ManSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManSalary manSalary = db.ManSalaries.Find(id);
            if (manSalary == null)
            {
                return HttpNotFound();
            }
            return View(manSalary);
        }

        // POST: ManSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            ManSalary manSalary = db.ManSalaries.Find(id);

            int ManId = manSalary.ManagerId;
            Manager m1 = db.Managers.Find(ManId);
            m1.Salary = m1.Salary - manSalary.SalaryAmn;

            db.ManSalaries.Remove(manSalary);
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
