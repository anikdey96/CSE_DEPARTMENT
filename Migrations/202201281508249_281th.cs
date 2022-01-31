namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _281th : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faculty_Application", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Faculty_Application", new[] { "Id" });
            CreateTable(
                "dbo.emFacultyInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Name = c.String(),
                        TotalLeave = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.moFacultyApplications",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        id = c.Int(),
                        name = c.String(),
                        title = c.String(nullable: false),
                        Designation = c.String(),
                        NoOfLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        status = c.String(),
                        Accepted_Rejected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.application_id)
                .ForeignKey("dbo.moFacultyInfoes", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.moFacultyInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Name = c.String(),
                        TotalLeave = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.shFacultyInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Name = c.String(),
                        TotalLeave = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.Faculty_Application", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faculty_Application", "Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.moFacultyApplications", "id", "dbo.moFacultyInfoes");
            DropIndex("dbo.moFacultyApplications", new[] { "id" });
            DropTable("dbo.shFacultyInfoes");
            DropTable("dbo.moFacultyInfoes");
            DropTable("dbo.moFacultyApplications");
            DropTable("dbo.emFacultyInfoes");
            CreateIndex("dbo.Faculty_Application", "Id");
            AddForeignKey("dbo.Faculty_Application", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
