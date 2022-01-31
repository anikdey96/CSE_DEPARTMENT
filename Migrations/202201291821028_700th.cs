namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _700th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "NoOfLeave", c => c.Int(nullable: false));
            AddColumn("dbo.Staff_Application", "NoOfLeave", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staff_Application", "NoOfLeave");
            DropColumn("dbo.Applications", "NoOfLeave");
        }
    }
}
