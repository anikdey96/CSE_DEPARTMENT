namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculty_Application", "name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculty_Application", "name", c => c.String(nullable: false));
        }
    }
}
