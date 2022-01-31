namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _291th : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculty_Application", "Designation", c => c.String(nullable: false));
            AlterColumn("dbo.Faculty_Application", "title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculty_Application", "title", c => c.String(nullable: false));
            DropColumn("dbo.Faculty_Application", "Designation");
        }
    }
}
