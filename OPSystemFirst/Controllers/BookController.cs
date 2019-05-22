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
    public class BookController : Controller
    {
        private BookingParkingContext db = new BookingParkingContext();

        // GET: Book
        public ActionResult ViewBook()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Book/Create
        public ActionResult Book()
        {
            var Values = new List<int> { 1, 2, 3, 4, 5, 6};
            var aList = Values.Select((x, i) => new { Value = (x < 12 ? x : 12), Data = x }).ToList();
            ViewBag.HoursList = new SelectList(aList, "Value", "Data");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "BookingId,name,PlateNumber,date,time,ParkingNo")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.payment = booking.totalDaily();
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("ViewBook");
            }

            return View(booking);
        }
    }
}
