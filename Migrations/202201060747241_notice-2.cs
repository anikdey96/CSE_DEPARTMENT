namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notice2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notices", "published_by", c => c.String());
            AddColumn("dbo.notices", "publish_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.notices", "updated_by", c => c.String());
            AddColumn("dbo.notices", "updated_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.notices", "created_by", c => c.String(nullable: false));
            AlterColumn("dbo.notices", "deadline", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.notices", "deadline", c => c.String());
            AlterColumn("dbo.notices", "created_by", c => c.String());
            DropColumn("dbo.notices", "updated_date");
            DropColumn("dbo.notices", "updated_by");
            DropColumn("dbo.notices", "publish_date");
            DropColumn("dbo.notices", "published_by");
        }
    }
}
