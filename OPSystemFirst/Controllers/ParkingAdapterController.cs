using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPSystemFirst.Models;
using Microsoft.SqlServer.Server;

namespace OPSystemFirst.Controllers
{
    public class ParkingAdapterController : Controller
    {
        private BookingParkingContext db = new BookingParkingContext();
        ParkingAdapter parkingAdapter = new ParkingAdapter();
        // GET: ParkingAdapter
        public ActionResult ParkingType()
        {
            return View();
        }

        // POST: ParkingAdapter
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
    }
}
