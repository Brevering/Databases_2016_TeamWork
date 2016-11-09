namespace CarsFactory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        OrderId = c.Int(),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.ModelId)
                .Index(t => t.DealerId)
                .Index(t => t.OrderId);

            this.CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TownId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.TownId, cascadeDelete: true)
                .Index(t => t.TownId);

            this.CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Year = c.DateTime(),
                        ManufacturerId = c.Int(nullable: false),
                        PlatformId = c.Int(nullable: false),
                        EngineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engines", t => t.EngineId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Platforms", t => t.PlatformId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.PlatformId)
                .Index(t => t.EngineId);

            this.CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fuel = c.Int(nullable: false),
                        HorsePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlatformType = c.Int(nullable: false),
                        NumberOfDoors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Cars", "OrderId", "dbo.Orders");
            this.DropForeignKey("dbo.Cars", "ModelId", "dbo.Models");
            this.DropForeignKey("dbo.Models", "PlatformId", "dbo.Platforms");
            this.DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            this.DropForeignKey("dbo.Models", "EngineId", "dbo.Engines");
            this.DropForeignKey("dbo.Dealers", "TownId", "dbo.Towns");
            this.DropForeignKey("dbo.Cars", "DealerId", "dbo.Dealers");
            this.DropIndex("dbo.Models", new[] { "EngineId" });
            this.DropIndex("dbo.Models", new[] { "PlatformId" });
            this.DropIndex("dbo.Models", new[] { "ManufacturerId" });
            this.DropIndex("dbo.Dealers", new[] { "TownId" });
            this.DropIndex("dbo.Cars", new[] { "OrderId" });
            this.DropIndex("dbo.Cars", new[] { "DealerId" });
            this.DropIndex("dbo.Cars", new[] { "ModelId" });
            this.DropTable("dbo.Orders");
            this.DropTable("dbo.Platforms");
            this.DropTable("dbo.Manufacturers");
            this.DropTable("dbo.Engines");
            this.DropTable("dbo.Models");
            this.DropTable("dbo.Towns");
            this.DropTable("dbo.Dealers");
            this.DropTable("dbo.Cars");
        }
    }
}
