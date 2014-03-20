namespace DBTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HostServers",
                c => new
                    {
                        HostServerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServerStatus = c.Int(nullable: false),
                        Specs = c.String(),
                    })
                .PrimaryKey(t => t.HostServerId);
            
            CreateTable(
                "dbo.ServerSlots",
                c => new
                    {
                        ServerSlotId = c.Int(nullable: false, identity: true),
                        HostServerId = c.Int(nullable: false),
                        IpAddress = c.String(),
                        KeySet_KeySetId = c.Int(),
                        ServerType_ServerTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ServerSlotId)
                .ForeignKey("dbo.KeySets", t => t.KeySet_KeySetId)
                .ForeignKey("dbo.ServerTypes", t => t.ServerType_ServerTypeId)
                .ForeignKey("dbo.HostServers", t => t.HostServerId, cascadeDelete: true)
                .Index(t => t.HostServerId)
                .Index(t => t.KeySet_KeySetId)
                .Index(t => t.ServerType_ServerTypeId);
            
            CreateTable(
                "dbo.KeySets",
                c => new
                    {
                        KeySetId = c.Int(nullable: false, identity: true),
                        PublicKeyFile_FilePath = c.String(),
                        PublicKeyFile_MimeType = c.String(),
                        PublicKeyFile_Size = c.Int(nullable: false),
                        PublicKeyFile_CreatedOn = c.DateTime(nullable: false),
                        PrivateKeyFile_FilePath = c.String(),
                        PrivateKeyFile_MimeType = c.String(),
                        PrivateKeyFile_Size = c.Int(nullable: false),
                        PrivateKeyFile_CreatedOn = c.DateTime(nullable: false),
                        ServerSlotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeySetId);
            
            CreateTable(
                "dbo.ServerTypes",
                c => new
                    {
                        ServerTypeId = c.Int(nullable: false, identity: true),
                        OperatingSystem = c.String(),
                        MemoryInMb = c.Int(nullable: false),
                        DiskSpaceInMb = c.Int(nullable: false),
                        CpuSpeedInMhz = c.Int(nullable: false),
                        AdditionalServices = c.String(),
                    })
                .PrimaryKey(t => t.ServerTypeId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        DurationInDays = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ConfirmedByUserId = c.Int(),
                        Comments = c.String(),
                        ServerSlot_ServerSlotId = c.Int(),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.ServerSlots", t => t.ServerSlot_ServerSlotId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ServerSlot_ServerSlotId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CredentialLevel = c.Int(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rentals", "ServerSlot_ServerSlotId", "dbo.ServerSlots");
            DropForeignKey("dbo.ServerSlots", "HostServerId", "dbo.HostServers");
            DropForeignKey("dbo.ServerSlots", "ServerType_ServerTypeId", "dbo.ServerTypes");
            DropForeignKey("dbo.ServerSlots", "KeySet_KeySetId", "dbo.KeySets");
            DropIndex("dbo.Rentals", new[] { "ServerSlot_ServerSlotId" });
            DropIndex("dbo.Rentals", new[] { "UserId" });
            DropIndex("dbo.ServerSlots", new[] { "ServerType_ServerTypeId" });
            DropIndex("dbo.ServerSlots", new[] { "KeySet_KeySetId" });
            DropIndex("dbo.ServerSlots", new[] { "HostServerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rentals");
            DropTable("dbo.ServerTypes");
            DropTable("dbo.KeySets");
            DropTable("dbo.ServerSlots");
            DropTable("dbo.HostServers");
        }
    }
}
