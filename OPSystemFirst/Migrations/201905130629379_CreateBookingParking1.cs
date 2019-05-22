namespace OPSystemFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBookingParking1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingAdapters",
                c => new
                    {
                        ParkingAdapterId = c.Int(nullable: false, identity: true),
                        parkingType = c.String(),
                    })
                .PrimaryKey(t => t.ParkingAdapterId);
            
            CreateTable(
                "dbo.paymentModels",
                c => new
                    {
                        paymentModelId = c.Int(nullable: false, identity: true),
                        pricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        hour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.paymentModelId);
            
            CreateTable(
                "dbo.ReserveBayAdaptees",
                c => new
                    {
                        ReserveBayAdapteeId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45),
                        lotAddress = c.String(nullable: false, maxLength: 12),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReserveBayAdapteeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReserveBayAdaptees");
            DropTable("dbo.paymentModels");
            DropTable("dbo.ParkingAdapters");
        }
    }
}
