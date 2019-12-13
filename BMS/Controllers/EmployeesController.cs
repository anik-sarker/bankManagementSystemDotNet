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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Branch);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult notices()
        {
            db.EmpNoticeBoards.Where(c => c.Seen == false);
            return View(db.EmpNoticeBoards.Where(c => c.Seen == false));
        }


        public ActionResult noticesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpNoticeBoard empNoticeBoard = db.EmpNoticeBoards.Find(id);
            empNoticeBoard.Seen = true;
            db.SaveChanges();

            if (empNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(empNoticeBoard);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateOfBirth,Email,PhoneNumber,Address,Gender,NID,BranchId,Salary,JoinDate,Password,EmpPoints")] Employee employee)
        {
            var unitofwork = new UnitOFWork.UnitOfWork(db);
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                Branch branch = db.Branches.Find(employee.BranchId);
                branch.CurrentEmployees = branch.CurrentEmployees + 1;    //employe +1 in branch

                UserInfo ui = new UserInfo();                           //added on userinfo
                ui.UserId = employee.Id;
                ui.UserPasssword = employee.Password;
                ui.UserRole = "Emp";

                unitofwork.UserInfo.Add(ui);
                unitofwork.Complete();


                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateOfBirth,Email,PhoneNumber,Address,Gender,NID,BranchId,Salary,JoinDate,Password,EmpPoints")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", employee.BranchId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee emp = db.Employees.Find(id);
            Branch branch = db.Branches.Find(emp.BranchId);
            branch.CurrentEmployees = branch.CurrentEmployees - 1;

            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
