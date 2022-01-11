namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studenttask2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.student_task_assign", "currentacademic_id", "dbo.current_academic");
            DropIndex("dbo.student_task_assign", new[] { "currentacademic_id" });
            AddColumn("dbo.student_task_assign", "roll", c => c.Int(nullable: false));
            DropColumn("dbo.student_task_assign", "currentacademic_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.student_task_assign", "currentacademic_id", c => c.Int());
            DropColumn("dbo.student_task_assign", "roll");
            CreateIndex("dbo.student_task_assign", "currentacademic_id");
            AddForeignKey("dbo.student_task_assign", "currentacademic_id", "dbo.current_academic", "currentacademic_id");
        }
    }
}
