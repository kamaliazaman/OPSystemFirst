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
    public class ParkingSystemController : Controller
    {
        private BookingParkingContext db = new BookingParkingContext();

        // GET: ParkingSystem/Create
        public ActionResult SignUp()
        {
            
            return View();
        }

        // POST: ParkingSystem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "SignUpId,name,ICno,Address,PlateNumber,email,PaymentMethod")] SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                db.SignUps.Add(signUp);
                db.SaveChanges();
                return RedirectToAction("ParkingType", "ParkingAdapter");
            }
            return View(signUp);
        }

    }
}
