namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.activities", "Roll", c => c.Int(nullable: false));
            AlterColumn("dbo.current_academic", "Roll", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.current_academic", "Roll", c => c.String());
            DropColumn("dbo.activities", "Roll");
        }
    }
}
