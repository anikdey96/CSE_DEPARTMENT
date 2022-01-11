namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carec1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.current_academic", "Email", c => c.String(nullable: false));
        }
    }
}
