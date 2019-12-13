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
    public class EmpSalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmpSalaries
        public ActionResult Index()
        {
            var empSalaries = db.EmpSalaries.Include(e => e.Employee);
            return View(empSalaries.ToList());
        }

        // GET: EmpSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSalary empSalary = db.EmpSalaries.Find(id);
            if (empSalary == null)
            {
                return HttpNotFound();
            }
            return View(empSalary);
        }

        // GET: EmpSalaries/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: EmpSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,SalaryAmn,Date")] EmpSalary empSalary)
        {
            if (ModelState.IsValid)
            {
                db.EmpSalaries.Add(empSalary);
                db.SaveChanges();

                Employee e1 = db.Employees.Find(empSalary.EmployeeId);
                e1.Salary = e1.Salary + empSalary.SalaryAmn;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", empSalary.EmployeeId);
            return View(empSalary);
        }

        // GET: EmpSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSalary empSalary = db.EmpSalaries.Find(id);
            if (empSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", empSalary.EmployeeId);
            return View(empSalary);
        }

        // POST: EmpSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,SalaryAmn,Date")] EmpSalary empSalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", empSalary.EmployeeId);
            return View(empSalary);
        }

        // GET: EmpSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpSalary empSalary = db.EmpSalaries.Find(id);
            if (empSalary == null)
            {
                return HttpNotFound();
            }
            return View(empSalary);
        }

        // POST: EmpSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpSalary empSalary = db.EmpSalaries.Find(id);

            int EmpId = empSalary.EmployeeId;
            Employee e1 = db.Employees.Find(EmpId);
            e1.Salary = e1.Salary - empSalary.SalaryAmn;

            db.EmpSalaries.Remove(empSalary);
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
