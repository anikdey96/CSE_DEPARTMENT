namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookupload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "Photo");
        }
    }
}
