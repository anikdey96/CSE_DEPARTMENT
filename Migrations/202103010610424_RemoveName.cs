namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "Name");
            DropColumn("dbo.previous_academic", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.previous_academic", "Name", c => c.String(nullable: false));
            AddColumn("dbo.current_academic", "Name", c => c.String(nullable: false));
        }
    }
}
