using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OPSystemFirst.Models
{
    public class SignUp
    {
        public int SignUpId { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "Max is 45 character", MinimumLength = 5)]
        [Display(Name = "Full Name : ", Prompt = "Please fill in your full name ")]
        public string name { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Max is 15 character", MinimumLength = 12)]
        [Display(Name = "IC number : ", Prompt = "example = 961231011234 ")]
        public string ICno { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Max is 80 character", MinimumLength = 5)]
        [Display(Name = "Address : ", Prompt = "example- 01 Jalan Universiti Taman Teknologi 81300 Skudai Johor")]
        public string Address { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Max is 12 character", MinimumLength = 5)]
        [Display(Name = "Plate Number : ", Prompt = "example- JDT2019")]
        public string PlateNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max is 60 character", MinimumLength = 5)]
        [Display(Name = "Email : ", Prompt = "example@example.com.my")]
        public string email { get; set; }

        [Required]
        
        [Display(Name = "Payment Method : ", Prompt = "Credit/Debit (either one)")]
        public string PaymentMethod { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<ParkingAdapter> ParkingAdapters { get; set; }
        public List<ReserveBayAdaptee> ReserveBayAdaptees { get; set; }
        public List<daily> dailys { get; set; }
        public List<monthly> monthlys { get; set; }
    }
}