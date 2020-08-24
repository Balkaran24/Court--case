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
    public class LawyersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lawyers
        public ActionResult Index()
        {
            return View(db.Lawyers.ToList());
        }

        // GET: Lawyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // GET: Lawyers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lawyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Speciality,Age,MobileNumber")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Lawyers.Add(lawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lawyer);
        }

        // GET: Lawyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Speciality,Age,MobileNumber")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lawyer);
        }

        // GET: Lawyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lawyer lawyer = db.Lawyers.Find(id);
            db.Lawyers.Remove(lawyer);
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
