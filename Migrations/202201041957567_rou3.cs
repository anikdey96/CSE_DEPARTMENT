namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rou3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.current_academic", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.current_academic", "UserId");
        }
    }
}
