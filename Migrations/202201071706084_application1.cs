namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class application1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        application_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        roll = c.Int(nullable: false),
                        title = c.String(),
                        tag = c.String(),
                        description = c.String(),
                        status = c.String(),
                        year_id = c.Int(),
                    })
                .PrimaryKey(t => t.application_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "year_id", "dbo.Years");
            DropIndex("dbo.Applications", new[] { "year_id" });
            DropTable("dbo.Applications");
        }
    }
}
