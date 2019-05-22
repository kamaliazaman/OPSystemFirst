using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OPSystemFirst.Models
{
    public class BookingParkingContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<ReserveBayAdaptee> ReserveBayAdaptees { get; set; }
        public DbSet<ParkingAdapter> ParkingAdapters { get; set; }
        public DbSet<daily> dailys { get; set; }
        public DbSet<monthly> monthly { get; set; }
    }
}