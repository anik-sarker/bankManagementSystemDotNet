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
    public class EmpNoticeBoards1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmpNoticeBoards1
        public ActionResult Index()
        {
            return View(db.EmpNoticeBoards.ToList());
        }

        // GET: EmpNoticeBoards1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpNoticeBoard empNoticeBoard = db.EmpNoticeBoards.Find(id);
            if (empNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(empNoticeBoard);
        }

        // GET: EmpNoticeBoards1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpNoticeBoards1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,MesBody,Seen")] EmpNoticeBoard empNoticeBoard)
        {
            if (ModelState.IsValid)
            {
                db.EmpNoticeBoards.Add(empNoticeBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empNoticeBoard);
        }

        // GET: EmpNoticeBoards1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpNoticeBoard empNoticeBoard = db.EmpNoticeBoards.Find(id);
            if (empNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(empNoticeBoard);
        }

        // POST: EmpNoticeBoards1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,MesBody,Seen")] EmpNoticeBoard empNoticeBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empNoticeBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empNoticeBoard);
        }

        // GET: EmpNoticeBoards1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpNoticeBoard empNoticeBoard = db.EmpNoticeBoards.Find(id);
            if (empNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(empNoticeBoard);
        }

        // POST: EmpNoticeBoards1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpNoticeBoard empNoticeBoard = db.EmpNoticeBoards.Find(id);
            db.EmpNoticeBoards.Remove(empNoticeBoard);
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
