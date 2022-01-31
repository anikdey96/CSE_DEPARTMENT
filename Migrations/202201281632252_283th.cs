namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _283th : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Faculty_Application", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faculty_Application", "Designation", c => c.String());
        }
    }
}
