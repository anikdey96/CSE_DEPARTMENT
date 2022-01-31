namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _292th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.moDesignations",
                c => new
                    {
                        did = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.did);
            
            AddColumn("dbo.moFacultyApplications", "did", c => c.Int());
            CreateIndex("dbo.moFacultyApplications", "did");
            AddForeignKey("dbo.moFacultyApplications", "did", "dbo.moDesignations", "did");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.moFacultyApplications", "did", "dbo.moDesignations");
            DropIndex("dbo.moFacultyApplications", new[] { "did" });
            DropColumn("dbo.moFacultyApplications", "did");
            DropTable("dbo.moDesignations");
        }
    }
}
