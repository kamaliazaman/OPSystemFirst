using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Max is 45 character", MinimumLength = 5)]
        [Display(Name = "Full Name : ", Prompt = "Please fill in your full name ")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Date : ", Prompt = "example - 5MK7  ")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Time : ")]
        public int time { get; set; }

        [Required]
        [Display(Name = "Parking No : ", Prompt = "example - 5MK7  ")]
        public string ParkingNo { get; set; }
        public double payment { get; set; }

        public int? SignUpId { get; set; }
        public SignUp SignUp { get; set; }

        public int? ParkingAdapterId { get; set; }
        public ParkingAdapter ParkingAdapter { get; set; }

        public List<daily> dailys { get; set; }

       

        public double totalDaily()
        {
            daily d = new daily();
            d.pricePerHour = 0.6;

            d.total = (d.pricePerHour * (time));

            return d.total;
        }
    }
}