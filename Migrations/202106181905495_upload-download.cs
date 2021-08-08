namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uploaddownload : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.notices", "File", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.notices", "File", c => c.String());
        }
    }
}
