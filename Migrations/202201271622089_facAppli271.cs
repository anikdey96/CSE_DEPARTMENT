namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facAppli271 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculty_Application", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Faculty_Application", "Id");
            AddForeignKey("dbo.Faculty_Application", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faculty_Application", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Faculty_Application", new[] { "Id" });
            DropColumn("dbo.Faculty_Application", "Id");
        }
    }
}
