namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoField2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teachers", "ImageID", c => c.Int(nullable: false));
            AddColumn("dbo.teachers", "ImagePath", c => c.String());
            DropColumn("dbo.teachers", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teachers", "Photo", c => c.String());
            DropColumn("dbo.teachers", "ImagePath");
            DropColumn("dbo.teachers", "ImageID");
        }
    }
}
