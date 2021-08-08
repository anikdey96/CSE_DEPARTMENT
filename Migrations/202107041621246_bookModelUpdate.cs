namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "Pdf", c => c.String());
            DropColumn("dbo.books", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "Photo", c => c.String());
            DropColumn("dbo.books", "Pdf");
        }
    }
}
