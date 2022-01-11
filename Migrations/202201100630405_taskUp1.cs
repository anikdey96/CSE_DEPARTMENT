namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskUp1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.faculty_task_assign", "teacher_id", c => c.Int());
            AddColumn("dbo.staff_task_assign", "staff_id", c => c.Int());
            AddColumn("dbo.student_task_assign", "student_id", c => c.Int());
            AddColumn("dbo.student_task_assign", "session_id", c => c.Int());
            AddColumn("dbo.student_task_assign", "year_id", c => c.Int());
            CreateIndex("dbo.faculty_task_assign", "teacher_id");
            CreateIndex("dbo.staff_task_assign", "staff_id");
            CreateIndex("dbo.student_task_assign", "student_id");
            CreateIndex("dbo.student_task_assign", "session_id");
            CreateIndex("dbo.student_task_assign", "year_id");
            AddForeignKey("dbo.faculty_task_assign", "teacher_id", "dbo.teachers", "teacher_id");
            AddForeignKey("dbo.staff_task_assign", "staff_id", "dbo.Staffs", "staff_id");
            AddForeignKey("dbo.student_task_assign", "session_id", "dbo.Sessions", "session_id");
            AddForeignKey("dbo.student_task_assign", "student_id", "dbo.students", "student_id");
            AddForeignKey("dbo.student_task_assign", "year_id", "dbo.Years", "year_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.student_task_assign", "year_id", "dbo.Years");
            DropForeignKey("dbo.student_task_assign", "student_id", "dbo.students");
            DropForeignKey("dbo.student_task_assign", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.staff_task_assign", "staff_id", "dbo.Staffs");
            DropForeignKey("dbo.faculty_task_assign", "teacher_id", "dbo.teachers");
            DropIndex("dbo.student_task_assign", new[] { "year_id" });
            DropIndex("dbo.student_task_assign", new[] { "session_id" });
            DropIndex("dbo.student_task_assign", new[] { "student_id" });
            DropIndex("dbo.staff_task_assign", new[] { "staff_id" });
            DropIndex("dbo.faculty_task_assign", new[] { "teacher_id" });
            DropColumn("dbo.student_task_assign", "year_id");
            DropColumn("dbo.student_task_assign", "session_id");
            DropColumn("dbo.student_task_assign", "student_id");
            DropColumn("dbo.staff_task_assign", "staff_id");
            DropColumn("dbo.faculty_task_assign", "teacher_id");
        }
    }
}
