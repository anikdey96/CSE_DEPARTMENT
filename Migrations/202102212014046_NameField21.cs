namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameField21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.activities", "Name", c => c.Int(nullable: false));
            AddColumn("dbo.results", "Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.results", "Name");
            DropColumn("dbo.activities", "Name");
        }
    }
}
