namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAdd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.activities", "Name", c => c.String());
            AlterColumn("dbo.results", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.results", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.activities", "Name", c => c.Int(nullable: false));
        }
    }
}
