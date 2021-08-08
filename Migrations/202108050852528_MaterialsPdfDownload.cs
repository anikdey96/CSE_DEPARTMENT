namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterialsPdfDownload : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.materials", "materials_topic", c => c.String(nullable: false));
            DropColumn("dbo.materials", "File");
            DropColumn("dbo.materials", "Size");
            DropColumn("dbo.materials", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.materials", "Type", c => c.String());
            AddColumn("dbo.materials", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.materials", "File", c => c.String(nullable: false));
            AlterColumn("dbo.materials", "materials_topic", c => c.String());
        }
    }
}
