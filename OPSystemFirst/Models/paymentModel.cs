using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class paymentModel
    {
        public int paymentModelId { get; set; }
        public decimal pricePerHour { get; set; }
        public decimal total { get; set; }
        public int hour { get; set; }
    }
}