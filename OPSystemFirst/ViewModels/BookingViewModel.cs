using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OPSystemFirst.Models;

namespace OPSystemFirst.ViewModels
{
    public class BookingViewModel

    {
        public virtual Booking Booking { get; set; }
        public virtual SignUp SignUp { get; set; }
        public virtual daily Daily { get; set; }

        public virtual monthly Monthly { get; set; }
        public virtual ParkingAdapter ParkingAdapter { get; set; }
        public virtual ReserveBayAdaptee ReserveBayAdaptee { get; set; }
        public List<Booking> Bookings { get; set; }
        public BookingViewModel()
        {
            Bookings = new List<Booking>();
        }

    }
}