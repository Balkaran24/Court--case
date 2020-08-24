using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourtCases_Balkaran.Models;

namespace CourtCases_Balkaran.Controllers
{
    public class HearingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hearings
        public ActionResult Index()
        {
            var hearings = db.Hearings.Include(h => h.Case);
            return View(hearings.ToList());
        }

        // GET: Hearings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hearing hearing = db.Hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            return View(hearing);
        }

        // GET: Hearings/Create
        public ActionResult Create()
        {
            ViewBag.CaseID = new SelectList(db.Cases, "ID", "Name");
            return View();
        }

        // POST: Hearings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaseID,CurrentDate,NextDate")] Hearing hearing)
        {
            if (ModelState.IsValid)
            {
                db.Hearings.Add(hearing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseID = new SelectList(db.Cases, "ID", "Name", hearing.CaseID);
            return View(hearing);
        }

        // GET: Hearings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hearing hearing = db.Hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseID = new SelectList(db.Cases, "ID", "Name", hearing.CaseID);
            return View(hearing);
        }

        // POST: Hearings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaseID,CurrentDate,NextDate")] Hearing hearing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hearing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseID = new SelectList(db.Cases, "ID", "Name", hearing.CaseID);
            return View(hearing);
        }

        // GET: Hearings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hearing hearing = db.Hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            return View(hearing);
        }

        // POST: Hearings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hearing hearing = db.Hearings.Find(id);
            db.Hearings.Remove(hearing);
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
