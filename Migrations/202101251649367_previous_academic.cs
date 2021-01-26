namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class previous_academic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.previous_academic", "co_curricular_activities", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.previous_academic", "co_curricular_activities");
        }
    }
}
