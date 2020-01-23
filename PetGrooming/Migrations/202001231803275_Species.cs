namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Species : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroomBookings",
                c => new
                    {
                        GroomBookingID = c.Int(nullable: false, identity: true),
                        GroomBookingDate = c.DateTime(nullable: false),
                        GroomBookingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GroomBookingID);
            
            CreateTable(
                "dbo.GroomServices",
                c => new
                    {
                        GroomServiceID = c.Int(nullable: false, identity: true),
                        GroomServiceName = c.String(),
                        GroomServiceCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroomServiceDur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomServiceID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        OwnerFName = c.String(),
                        OwnerLName = c.String(),
                        OwnerAddress = c.String(),
                        OwnerWPNum = c.String(),
                        OwnerHPNum = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            AlterColumn("dbo.Groomers", "GroomerDOB", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groomers", "GroomerDOB", c => c.DateTime(nullable: false));
            DropTable("dbo.Owners");
            DropTable("dbo.GroomServices");
            DropTable("dbo.GroomBookings");
        }
    }
}
