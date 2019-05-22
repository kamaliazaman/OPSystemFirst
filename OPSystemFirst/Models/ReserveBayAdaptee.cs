using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class ReserveBayAdaptee
    {
        public int ReserveBayAdapteeId { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Max is 45 character", MinimumLength = 5)]
        [Display(Name = "Full Name : ", Prompt = "Please fill in your full name ")]
        public string name { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Max is 12 character", MinimumLength = 4)]
        [Display(Name = "Lot Address : ", Prompt = "example- 109A")]
        public string lotAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date : ", Prompt = "example- 109A")]
        public DateTime startDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date : ", Prompt = "example- 109A")]
        public DateTime endDate { get; set; }

        public double payment { get; set; }


        //TimeSpan difference = endDate - startDate;
        public int? SignUpId { get; set; }
        public SignUp SignUp { get; set; }

        public int? ParkingAdapterId { get; set; }
        public ParkingAdapter ParkingAdapter { get; set; }

        public List<monthly> monthlys { get; set; }

      

        public double totalMonthly()
        {
            monthly d = new monthly();
            d.pricePerMonth= 15;
            TimeSpan t = this.endDate - this.startDate;
            double numdays = t.TotalDays;
            d.total = (d.pricePerMonth * (numdays));

            return d.total;
        }
    }
}