namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rou4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.current_academic", "UserId", c => c.String());
        }
    }
}
