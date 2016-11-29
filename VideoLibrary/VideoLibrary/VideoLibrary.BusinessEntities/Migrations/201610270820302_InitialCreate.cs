namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditTrail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TableName = c.String(),
                        UserName = c.String(),
                        Actions = c.String(),
                        OldData = c.String(),
                        NewData = c.String(),
                        ChangedColums = c.String(),
                        TableIdValue = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                        Actor_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actor", t => t.Actor_Id)
                .Index(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Actor_Id", "dbo.Actor");
            DropIndex("dbo.Movie", new[] { "Actor_Id" });
            DropTable("dbo.Movie");
            DropTable("dbo.Client");
            DropTable("dbo.AuditTrail");
            DropTable("dbo.Actor");
        }
    }
}
