namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class current_academic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.current_academic", "co_curricular_activities", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.current_academic", "co_curricular_activities");
        }
    }
}
