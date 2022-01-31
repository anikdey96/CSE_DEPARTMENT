namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _282th : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.moFacultyApplications", "name");
            DropColumn("dbo.moFacultyApplications", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.moFacultyApplications", "Designation", c => c.String());
            AddColumn("dbo.moFacultyApplications", "name", c => c.String());
        }
    }
}
