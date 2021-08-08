namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class previousbookview : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.books", "File");
            DropColumn("dbo.books", "Size");
            DropColumn("dbo.books", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Type", c => c.String());
            AddColumn("dbo.books", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.books", "File", c => c.String(nullable: false));
        }
    }
}
