using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class monthly
    {
        public int monthlyId { get; set; }
        public double pricePerMonth { get; set; }
        public double total { get; set; }
        public int month { get; set; }

        public int? SignUpId { get; set; }
        public SignUp SignUp { get; set; }

        public int? ReserveBayAdapteeId { get; set; }
        public ReserveBayAdaptee ReserveBayAdaptee { get; set; }
    }
}