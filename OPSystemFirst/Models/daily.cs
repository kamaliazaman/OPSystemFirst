using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class daily
    {
        public int dailyId { get; set; }
        public double pricePerHour { get; set; }
        public double total { get; set; }
        public int hour { get; set; }

        public int? SignUpId { get; set; }
        public SignUp SignUp { get; set; }

        public int? BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}