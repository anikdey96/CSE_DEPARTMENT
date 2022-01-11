namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskassign4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.faculty_task_assign", "deadline", c => c.DateTime(nullable: false));
            AlterColumn("dbo.staff_task_assign", "deadline", c => c.DateTime(nullable: false));
            AlterColumn("dbo.student_task_assign", "deadline", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.student_task_assign", "deadline", c => c.String());
            AlterColumn("dbo.staff_task_assign", "deadline", c => c.String());
            AlterColumn("dbo.faculty_task_assign", "deadline", c => c.String());
        }
    }
}
