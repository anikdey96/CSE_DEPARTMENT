namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacStaUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculty_Application",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        title = c.String(),
                        tag = c.String(),
                        description = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.application_id);
            
            CreateTable(
                "dbo.Staff_Application",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        title = c.String(),
                        tag = c.String(),
                        description = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.application_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staff_Application");
            DropTable("dbo.Faculty_Application");
        }
    }
}
