namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskAssignStudent1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.student_task_assign", "session_id", "dbo.Sessions");
            DropIndex("dbo.student_task_assign", new[] { "session_id" });
            AddColumn("dbo.student_task_assign", "currentacademic_id", c => c.Int());
            CreateIndex("dbo.student_task_assign", "currentacademic_id");
            AddForeignKey("dbo.student_task_assign", "currentacademic_id", "dbo.current_academic", "currentacademic_id");
            DropColumn("dbo.student_task_assign", "session_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.student_task_assign", "session_id", c => c.Int());
            DropForeignKey("dbo.student_task_assign", "currentacademic_id", "dbo.current_academic");
            DropIndex("dbo.student_task_assign", new[] { "currentacademic_id" });
            DropColumn("dbo.student_task_assign", "currentacademic_id");
            CreateIndex("dbo.student_task_assign", "session_id");
            AddForeignKey("dbo.student_task_assign", "session_id", "dbo.Sessions", "session_id");
        }
    }
}
