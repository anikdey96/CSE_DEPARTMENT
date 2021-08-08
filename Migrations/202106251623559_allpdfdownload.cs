namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allpdfdownload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.routines", "File", c => c.String(nullable: false));
            AddColumn("dbo.routines", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.routines", "Type", c => c.String());
            AddColumn("dbo.books", "File", c => c.String(nullable: false));
            AddColumn("dbo.books", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.books", "Type", c => c.String());
            AddColumn("dbo.materials", "File", c => c.String(nullable: false));
            AddColumn("dbo.materials", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.materials", "Type", c => c.String());
            AlterColumn("dbo.materials", "materials_topic", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.materials", "materials_topic", c => c.String(nullable: false));
            DropColumn("dbo.materials", "Type");
            DropColumn("dbo.materials", "Size");
            DropColumn("dbo.materials", "File");
            DropColumn("dbo.books", "Type");
            DropColumn("dbo.books", "Size");
            DropColumn("dbo.books", "File");
            DropColumn("dbo.routines", "Type");
            DropColumn("dbo.routines", "Size");
            DropColumn("dbo.routines", "File");
        }
    }
}
