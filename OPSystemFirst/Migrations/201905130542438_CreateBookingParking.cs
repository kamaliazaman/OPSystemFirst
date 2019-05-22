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
                        PlateNumber = c.String(nullable: false, maxLength: 12),
                        date = c.DateTime(nullable: false),
                        time = c.String(nullable: false),
                        ParkingNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
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
                        BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.SignUpId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .Index(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SignUps", "BookingId", "dbo.Bookings");
            DropIndex("dbo.SignUps", new[] { "BookingId" });
            DropTable("dbo.SignUps");
            DropTable("dbo.Bookings");
        }
    }
}
