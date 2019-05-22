using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPSystemFirst.Models;

namespace OPSystemFirst.Controllers
{
    public class ParkingAdaptersController : Controller
    {
        private BookingParkingContext db = new BookingParkingContext();

        // GET: ParkingAdapters
        public ActionResult ParkingType()
        {
            
            //var parkingAdapters = db.ParkingAdapters.Include(p => p.SignUp);
            return View();
        }

        // GET: ParkingAdapters
        [HttpPost]
        public ActionResult ParkingType(string parkingType)
        {
            if (parkingType == "NormalParking")
            {
                return RedirectToAction("Book", "book");

            }
            else
            {
                return RedirectToAction("ReserveBay", "ReserveBay");
            }

        }

        // GET: ParkingAdapters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAdapter parkingAdapter = db.ParkingAdapters.Find(id);
            if (parkingAdapter == null)
            {
                return HttpNotFound();
            }
            return View(parkingAdapter);
        }

        // GET: ParkingAdapters/Create
        public ActionResult Create()
        {
            ViewBag.SignUpId = new SelectList(db.SignUps, "SignUpId", "name");
            return View();
        }

        // POST: ParkingAdapters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingAdapterId,parkingType,SignUpId")] ParkingAdapter parkingAdapter)
        {
            if (ModelState.IsValid)
            {
                db.ParkingAdapters.Add(parkingAdapter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SignUpId = new SelectList(db.SignUps, "SignUpId", "name", parkingAdapter.SignUpId);
            return View(parkingAdapter);
        }

        // GET: ParkingAdapters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAdapter parkingAdapter = db.ParkingAdapters.Find(id);
            if (parkingAdapter == null)
            {
                return HttpNotFound();
            }
            ViewBag.SignUpId = new SelectList(db.SignUps, "SignUpId", "name", parkingAdapter.SignUpId);
            return View(parkingAdapter);
        }

        // POST: ParkingAdapters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingAdapterId,parkingType,SignUpId")] ParkingAdapter parkingAdapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingAdapter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SignUpId = new SelectList(db.SignUps, "SignUpId", "name", parkingAdapter.SignUpId);
            return View(parkingAdapter);
        }

        // GET: ParkingAdapters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAdapter parkingAdapter = db.ParkingAdapters.Find(id);
            if (parkingAdapter == null)
            {
                return HttpNotFound();
            }
            return View(parkingAdapter);
        }

        // POST: ParkingAdapters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingAdapter parkingAdapter = db.ParkingAdapters.Find(id);
            db.ParkingAdapters.Remove(parkingAdapter);
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
