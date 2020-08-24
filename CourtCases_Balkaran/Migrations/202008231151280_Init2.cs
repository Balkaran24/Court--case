namespace CourtCases_Balkaran.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JudgeID = c.Int(nullable: false),
                        LawyerID = c.Int(nullable: false),
                        PartyID = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Judges", t => t.JudgeID, cascadeDelete: true)
                .ForeignKey("dbo.Lawyers", t => t.LawyerID, cascadeDelete: true)
                .ForeignKey("dbo.Parties", t => t.PartyID, cascadeDelete: true)
                .Index(t => t.JudgeID)
                .Index(t => t.LawyerID)
                .Index(t => t.PartyID);
            
            CreateTable(
                "dbo.Hearings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CaseID = c.Int(nullable: false),
                        CurrentDate = c.DateTime(nullable: false),
                        NextDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cases", t => t.CaseID, cascadeDelete: true)
                .Index(t => t.CaseID);
            
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Speciality = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lawyers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Speciality = c.String(),
                        Age = c.Int(nullable: false),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourtRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "PartyID", "dbo.Parties");
            DropForeignKey("dbo.Cases", "LawyerID", "dbo.Lawyers");
            DropForeignKey("dbo.Cases", "JudgeID", "dbo.Judges");
            DropForeignKey("dbo.Hearings", "CaseID", "dbo.Cases");
            DropIndex("dbo.Hearings", new[] { "CaseID" });
            DropIndex("dbo.Cases", new[] { "PartyID" });
            DropIndex("dbo.Cases", new[] { "LawyerID" });
            DropIndex("dbo.Cases", new[] { "JudgeID" });
            DropTable("dbo.CourtRooms");
            DropTable("dbo.Parties");
            DropTable("dbo.Lawyers");
            DropTable("dbo.Judges");
            DropTable("dbo.Hearings");
            DropTable("dbo.Cases");
        }
    }
}
