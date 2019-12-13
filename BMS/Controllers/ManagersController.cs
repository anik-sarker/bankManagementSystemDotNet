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
    public class ManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult notices()
        {
            db.ManNoticeBoards.Where(c=>c.Seen == false);
            return View(db.ManNoticeBoards.Where(c => c.Seen == false));
        }


        public ActionResult noticesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            manNoticeBoard.Seen = true;
            db.SaveChanges();

            if (manNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(manNoticeBoard);
        }

        public ActionResult Home()
        {
            return View();
        }



        public ActionResult transection()
      {
          return RedirectToAction("Index","MangrTransections");
      }

        // GET: Managers
        public ActionResult Index()
        {

            var managers = db.Managers.Include(m => m.Branch);
            return View(managers.ToList());
        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DateOfBirth,Email,PhoneNumber,Gender,NID,BranchId,Salary,JoinDate,Password,ManPoints")] Manager manager)
        {
            var unitofwork = new UnitOFWork.UnitOfWork(db);

            if (ModelState.IsValid)
            {

                db.Managers.Add(manager);
                db.SaveChanges();

                Branch branch = db.Branches.Find(manager.BranchId);
                branch.CurrentManagers = branch.CurrentManagers + 1; // brach employee added

                UserInfo un = new UserInfo();           //userinfo added on userinfo table
                un.UserId = manager.Id;
                un.UserPasssword = manager.Password;
                un.UserRole = "Man";
                
                unitofwork.UserInfo.Add(un);
                unitofwork.Complete();


                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", manager.BranchId);
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", manager.BranchId);
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateOfBirth,Email,PhoneNumber,Gender,NID,BranchId,Salary,JoinDate,Password,ManPoints")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "Name", manager.BranchId);
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager man = db.Managers.Find(id);
            Branch branch = db.Branches.Find(man.BranchId);
            branch.CurrentManagers = branch.CurrentManagers - 1;

            Manager manager = db.Managers.Find(id);
            db.Managers.Remove(manager);
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
