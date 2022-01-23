namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkboxApplication1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Accepted_Rejected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Faculty_Application", "Accepted_Rejected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staff_Application", "Accepted_Rejected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staff_Application", "Accepted_Rejected");
            DropColumn("dbo.Faculty_Application", "Accepted_Rejected");
            DropColumn("dbo.Applications", "Accepted_Rejected");
        }
    }
}
