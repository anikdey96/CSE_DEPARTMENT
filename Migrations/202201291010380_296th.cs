namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _296th : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.emFacultyApplications", "name");
            DropColumn("dbo.emFacultyApplications", "Designation");
            DropColumn("dbo.shaFacultyApplications", "name");
            DropColumn("dbo.shaFacultyApplications", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.shaFacultyApplications", "Designation", c => c.String());
            AddColumn("dbo.shaFacultyApplications", "name", c => c.String());
            AddColumn("dbo.emFacultyApplications", "Designation", c => c.String());
            AddColumn("dbo.emFacultyApplications", "name", c => c.String());
        }
    }
}
