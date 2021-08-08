namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noticeUploadDownload : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.notices", "Pdf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.notices", "Pdf", c => c.String());
        }
    }
}
