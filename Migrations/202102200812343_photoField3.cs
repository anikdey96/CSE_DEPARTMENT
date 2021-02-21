namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoField3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "Photo", c => c.String());
            DropColumn("dbo.teachers", "ImageID");
            DropColumn("dbo.teachers", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "ImagePath", c => c.String());
            AddColumn("dbo.teachers", "ImageID", c => c.Int(nullable: false));
            DropColumn("dbo.teachers", "Photo");
        }
    }
}
