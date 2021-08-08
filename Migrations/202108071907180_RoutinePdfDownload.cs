namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutinePdfDownload : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.routines", "File");
            DropColumn("dbo.routines", "Size");
            DropColumn("dbo.routines", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.routines", "Type", c => c.String());
            AddColumn("dbo.routines", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.routines", "File", c => c.String(nullable: false));
        }
    }
}
