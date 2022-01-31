namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class falast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculty_Application", "Designation", c => c.String());
            AddColumn("dbo.Faculty_Application", "NoOfLeave", c => c.Int(nullable: false));
            DropColumn("dbo.Faculty_Application", "tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faculty_Application", "tag", c => c.String());
            DropColumn("dbo.Faculty_Application", "NoOfLeave");
            DropColumn("dbo.Faculty_Application", "Designation");
        }
    }
}
