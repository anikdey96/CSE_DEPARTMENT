namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldRoutine2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.oldRoutines", "Room_No", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.oldRoutines", "Room_No");
        }
    }
}
