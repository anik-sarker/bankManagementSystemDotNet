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
    public class ManNoticeBoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManNoticeBoards
        public ActionResult Index()
        {
            return View(db.ManNoticeBoards.ToList());
        }

        // GET: ManNoticeBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            if (manNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(manNoticeBoard);
        }

        // GET: ManNoticeBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManNoticeBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,MesBody")] ManNoticeBoard manNoticeBoard)
        {
            if (ModelState.IsValid)
            {
                db.ManNoticeBoards.Add(manNoticeBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manNoticeBoard);
        }

        // GET: ManNoticeBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            if (manNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(manNoticeBoard);
        }

        // POST: ManNoticeBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,MesBody")] ManNoticeBoard manNoticeBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manNoticeBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manNoticeBoard);
        }

        // GET: ManNoticeBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            if (manNoticeBoard == null)
            {
                return HttpNotFound();
            }
            return View(manNoticeBoard);
        }

        // POST: ManNoticeBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManNoticeBoard manNoticeBoard = db.ManNoticeBoards.Find(id);
            db.ManNoticeBoards.Remove(manNoticeBoard);
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
