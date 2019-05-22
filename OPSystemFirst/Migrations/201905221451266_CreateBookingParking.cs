namespace OPSystemFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBookingParking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45),
                        date = c.DateTime(nullable: false),
                        time = c.Int(nullable: false),
                        ParkingNo = c.String(nullable: false),
                        payment = c.Double(nullable: false),
                        SignUpId = c.Int(),
                        ParkingAdapterId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.SignUps", t => t.SignUpId)
                .ForeignKey("dbo.ParkingAdapters", t => t.ParkingAdapterId)
                .Index(t => t.SignUpId)
                .Index(t => t.ParkingAdapterId);
            
            CreateTable(
                "dbo.dailies",
                c => new
                    {
                        dailyId = c.Int(nullable: false, identity: true),
                        pricePerHour = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        hour = c.Int(nullable: false),
                        SignUpId = c.Int(),
                        BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.dailyId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .ForeignKey("dbo.SignUps", t => t.SignUpId)
                .Index(t => t.SignUpId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                        SignUpId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45),
                        ICno = c.String(nullable: false, maxLength: 15),
                        Address = c.String(nullable: false, maxLength: 80),
                        PlateNumber = c.String(nullable: false, maxLength: 12),
                        email = c.String(nullable: false, maxLength: 50),
                        PaymentMethod = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SignUpId);
            
            CreateTable(
                "dbo.monthlies",
                c => new
                    {
                        monthlyId = c.Int(nullable: false, identity: true),
                        pricePerMonth = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                        month = c.Int(nullable: false),
                        SignUpId = c.Int(),
                        ReserveBayAdapteeId = c.Int(),
                    })
                .PrimaryKey(t => t.monthlyId)
                .ForeignKey("dbo.ReserveBayAdaptees", t => t.ReserveBayAdapteeId)
                .ForeignKey("dbo.SignUps", t => t.SignUpId)
                .Index(t => t.SignUpId)
                .Index(t => t.ReserveBayAdapteeId);
            
            CreateTable(
                "dbo.ReserveBayAdaptees",
                c => new
                    {
                        ReserveBayAdapteeId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45),
                        lotAddress = c.String(nullable: false, maxLength: 12),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        payment = c.Double(nullable: false),
                        SignUpId = c.Int(),
                        ParkingAdapterId = c.Int(),
                    })
                .PrimaryKey(t => t.ReserveBayAdapteeId)
                .ForeignKey("dbo.ParkingAdapters", t => t.ParkingAdapterId)
                .ForeignKey("dbo.SignUps", t => t.SignUpId)
                .Index(t => t.SignUpId)
                .Index(t => t.ParkingAdapterId);
            
            CreateTable(
                "dbo.ParkingAdapters",
                c => new
                    {
                        ParkingAdapterId = c.Int(nullable: false, identity: true),
                        parkingType = c.String(),
                        SignUpId = c.Int(),
                    })
                .PrimaryKey(t => t.ParkingAdapterId)
                .ForeignKey("dbo.SignUps", t => t.SignUpId)
                .Index(t => t.SignUpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.monthlies", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.ReserveBayAdaptees", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.ParkingAdapters", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.ReserveBayAdaptees", "ParkingAdapterId", "dbo.ParkingAdapters");
            DropForeignKey("dbo.Bookings", "ParkingAdapterId", "dbo.ParkingAdapters");
            DropForeignKey("dbo.monthlies", "ReserveBayAdapteeId", "dbo.ReserveBayAdaptees");
            DropForeignKey("dbo.dailies", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.Bookings", "SignUpId", "dbo.SignUps");
            DropForeignKey("dbo.dailies", "BookingId", "dbo.Bookings");
            DropIndex("dbo.ParkingAdapters", new[] { "SignUpId" });
            DropIndex("dbo.ReserveBayAdaptees", new[] { "ParkingAdapterId" });
            DropIndex("dbo.ReserveBayAdaptees", new[] { "SignUpId" });
            DropIndex("dbo.monthlies", new[] { "ReserveBayAdapteeId" });
            DropIndex("dbo.monthlies", new[] { "SignUpId" });
            DropIndex("dbo.dailies", new[] { "BookingId" });
            DropIndex("dbo.dailies", new[] { "SignUpId" });
            DropIndex("dbo.Bookings", new[] { "ParkingAdapterId" });
            DropIndex("dbo.Bookings", new[] { "SignUpId" });
            DropTable("dbo.ParkingAdapters");
            DropTable("dbo.ReserveBayAdaptees");
            DropTable("dbo.monthlies");
            DropTable("dbo.SignUps");
            DropTable("dbo.dailies");
            DropTable("dbo.Bookings");
        }
    }
}
