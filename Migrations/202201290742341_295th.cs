namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _295th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.emFacultyApplications",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        id = c.Int(),
                        did = c.Int(),
                        name = c.String(),
                        title = c.String(nullable: false),
                        Designation = c.String(),
                        NoOfLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        status = c.String(),
                        Accepted_Rejected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.application_id)
                .ForeignKey("dbo.designationEms", t => t.did)
                .ForeignKey("dbo.emFacultyInfoes", t => t.id)
                .Index(t => t.id)
                .Index(t => t.did);
            
            CreateTable(
                "dbo.shaFacultyApplications",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        id = c.Int(),
                        did = c.Int(),
                        name = c.String(),
                        title = c.String(nullable: false),
                        Designation = c.String(),
                        NoOfLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        status = c.String(),
                        Accepted_Rejected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.application_id)
                .ForeignKey("dbo.designationShas", t => t.did)
                .ForeignKey("dbo.shFacultyInfoes", t => t.id)
                .Index(t => t.id)
                .Index(t => t.did);
            
            AddColumn("dbo.moFacultyApplications", "did", c => c.Int());
            CreateIndex("dbo.moFacultyApplications", "did");
            AddForeignKey("dbo.moFacultyApplications", "did", "dbo.designationMoes", "did");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.shaFacultyApplications", "id", "dbo.shFacultyInfoes");
            DropForeignKey("dbo.shaFacultyApplications", "did", "dbo.designationShas");
            DropForeignKey("dbo.moFacultyApplications", "did", "dbo.designationMoes");
            DropForeignKey("dbo.emFacultyApplications", "id", "dbo.emFacultyInfoes");
            DropForeignKey("dbo.emFacultyApplications", "did", "dbo.designationEms");
            DropIndex("dbo.shaFacultyApplications", new[] { "did" });
            DropIndex("dbo.shaFacultyApplications", new[] { "id" });
            DropIndex("dbo.moFacultyApplications", new[] { "did" });
            DropIndex("dbo.emFacultyApplications", new[] { "did" });
            DropIndex("dbo.emFacultyApplications", new[] { "id" });
            DropColumn("dbo.moFacultyApplications", "did");
            DropTable("dbo.shaFacultyApplications");
            DropTable("dbo.emFacultyApplications");
        }
    }
}
