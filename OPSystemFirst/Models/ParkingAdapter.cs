using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class ParkingAdapter
    {
        public int ParkingAdapterId { get; set; }

        [Display(Name = "Parking Type : ")]
        public string parkingType { get; set; }

        public int? SignUpId { get; set; }
        public SignUp SignUp { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<ReserveBayAdaptee> ReserveBayAdaptees { get; set; }
    }
}