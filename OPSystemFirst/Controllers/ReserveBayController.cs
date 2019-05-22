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
    public class ReserveBayController : Controller
    {
        private BookingParkingContext db = new BookingParkingContext();

        // GET: ReserveBay
        public ActionResult ViewReserveReceipt()
        {
            return View(db.ReserveBayAdaptees.ToList());
        }

        // GET: ReserveBay/Create
        public ActionResult ReserveBay()
        {
            return View();
        }

        // POST: ReserveBay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveBay([Bind(Include = "ReserveBayAdapteeId,name,lotAddress,startDate,endDate")] ReserveBayAdaptee reserveBayAdaptee)
        {
            if (ModelState.IsValid)
            {
                reserveBayAdaptee.payment = reserveBayAdaptee.totalMonthly();
                db.ReserveBayAdaptees.Add(reserveBayAdaptee);
                db.SaveChanges();
                return RedirectToAction("ViewReserveReceipt");
            }

            return View(reserveBayAdaptee);
        }
    }
}
