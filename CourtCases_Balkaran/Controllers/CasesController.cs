﻿using System;
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
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cases
        public ActionResult Index()
        {
            var cases = db.Cases.Include(x => x.Judge).Include(x => x.Lawyer).Include(x => x.Party);
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public ActionResult Create()
        {
            ViewBag.JudgeID = new SelectList(db.Judges, "ID", "Name");
            ViewBag.LawyerID = new SelectList(db.Lawyers, "ID", "Name");
            ViewBag.PartyID = new SelectList(db.Parties, "ID", "Name");
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JudgeID,LawyerID,PartyID,Name,Type")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JudgeID = new SelectList(db.Judges, "ID", "Name", @case.JudgeID);
            ViewBag.LawyerID = new SelectList(db.Lawyers, "ID", "Name", @case.LawyerID);
            ViewBag.PartyID = new SelectList(db.Parties, "ID", "Name", @case.PartyID);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            ViewBag.JudgeID = new SelectList(db.Judges, "ID", "Name", @case.JudgeID);
            ViewBag.LawyerID = new SelectList(db.Lawyers, "ID", "Name", @case.LawyerID);
            ViewBag.PartyID = new SelectList(db.Parties, "ID", "Name", @case.PartyID);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JudgeID,LawyerID,PartyID,Name,Type")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JudgeID = new SelectList(db.Judges, "ID", "Name", @case.JudgeID);
            ViewBag.LawyerID = new SelectList(db.Lawyers, "ID", "Name", @case.LawyerID);
            ViewBag.PartyID = new SelectList(db.Parties, "ID", "Name", @case.PartyID);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
