namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rou11addcolum1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rou11", "year_id", c => c.Int());
            CreateIndex("dbo.rou11", "year_id");
            AddForeignKey("dbo.rou11", "year_id", "dbo.Years", "year_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rou11", "year_id", "dbo.Years");
            DropIndex("dbo.rou11", new[] { "year_id" });
            DropColumn("dbo.rou11", "year_id");
        }
    }
}
