namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rouup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.routines", "routine_upload");
            DropColumn("dbo.routines", "class_date");
            DropColumn("dbo.routines", "day");
            DropColumn("dbo.routines", "start_time");
            DropColumn("dbo.routines", "end_time");
            DropColumn("dbo.routines", "duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.routines", "duration", c => c.String(nullable: false));
            AddColumn("dbo.routines", "end_time", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.routines", "start_time", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.routines", "day", c => c.String(nullable: false));
            AddColumn("dbo.routines", "class_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.routines", "routine_upload", c => c.String());
        }
    }
}
