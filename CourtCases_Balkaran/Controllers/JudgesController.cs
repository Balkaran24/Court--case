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
    public class JudgesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Judges
        public ActionResult Index()
        {
            return View(db.Judges.ToList());
        }

        // GET: Judges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judge judge = db.Judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // GET: Judges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Judges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Speciality,Age")] Judge judge)
        {
            if (ModelState.IsValid)
            {
                db.Judges.Add(judge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judge);
        }

        // GET: Judges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judge judge = db.Judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // POST: Judges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Speciality,Age")] Judge judge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(judge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(judge);
        }

        // GET: Judges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judge judge = db.Judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // POST: Judges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Judge judge = db.Judges.Find(id);
            db.Judges.Remove(judge);
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
