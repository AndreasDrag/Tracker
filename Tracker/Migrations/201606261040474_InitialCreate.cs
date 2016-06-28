namespace Tracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approvals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetOwnerId = c.Int(nullable: false),
                        PetWalkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalkerId, cascadeDelete: true)
                .Index(t => t.PetOwnerId)
                .Index(t => t.PetWalkerId);
            
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PetWalkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        PetOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .Index(t => t.PetOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetOwnerId", "dbo.PetOwners");
            DropForeignKey("dbo.Approvals", "PetWalkerId", "dbo.PetWalkers");
            DropForeignKey("dbo.Approvals", "PetOwnerId", "dbo.PetOwners");
            DropIndex("dbo.Pets", new[] { "PetOwnerId" });
            DropIndex("dbo.Approvals", new[] { "PetWalkerId" });
            DropIndex("dbo.Approvals", new[] { "PetOwnerId" });
            DropTable("dbo.Pets");
            DropTable("dbo.PetWalkers");
            DropTable("dbo.PetOwners");
            DropTable("dbo.Approvals");
        }
    }
}
