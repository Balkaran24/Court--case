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
    public class CourtRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourtRooms
        public ActionResult Index()
        {
            return View(db.CourtRooms.ToList());
        }

        // GET: CourtRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoom courtRoom = db.CourtRooms.Find(id);
            if (courtRoom == null)
            {
                return HttpNotFound();
            }
            return View(courtRoom);
        }

        // GET: CourtRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomNumber")] CourtRoom courtRoom)
        {
            if (ModelState.IsValid)
            {
                db.CourtRooms.Add(courtRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtRoom);
        }

        // GET: CourtRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoom courtRoom = db.CourtRooms.Find(id);
            if (courtRoom == null)
            {
                return HttpNotFound();
            }
            return View(courtRoom);
        }

        // POST: CourtRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomNumber")] CourtRoom courtRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtRoom);
        }

        // GET: CourtRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtRoom courtRoom = db.CourtRooms.Find(id);
            if (courtRoom == null)
            {
                return HttpNotFound();
            }
            return View(courtRoom);
        }

        // POST: CourtRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtRoom courtRoom = db.CourtRooms.Find(id);
            db.CourtRooms.Remove(courtRoom);
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
