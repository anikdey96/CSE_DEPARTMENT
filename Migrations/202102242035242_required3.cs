namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.students", "session_id", "dbo.Sessions");
            DropIndex("dbo.students", new[] { "session_id" });
            AlterColumn("dbo.students", "session_id", c => c.Int(nullable: false));
            CreateIndex("dbo.students", "session_id");
            AddForeignKey("dbo.students", "session_id", "dbo.Sessions", "session_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.students", "session_id", "dbo.Sessions");
            DropIndex("dbo.students", new[] { "session_id" });
            AlterColumn("dbo.students", "session_id", c => c.Int());
            CreateIndex("dbo.students", "session_id");
            AddForeignKey("dbo.students", "session_id", "dbo.Sessions", "session_id");
        }
    }
}
