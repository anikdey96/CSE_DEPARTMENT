namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PdfDownloadUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "File", c => c.String());
            AddColumn("dbo.books", "Size", c => c.Long());
            AddColumn("dbo.books", "Type", c => c.String());
            DropColumn("dbo.books", "Pdf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Pdf", c => c.String());
            DropColumn("dbo.books", "Type");
            DropColumn("dbo.books", "Size");
            DropColumn("dbo.books", "File");
        }
    }
}
