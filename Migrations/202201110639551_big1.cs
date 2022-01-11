namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class big1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Applications", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Faculty_Application", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Faculty_Application", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Faculty_Application", "description", c => c.String(nullable: false));
            AlterColumn("dbo.faculty_task_assign", "title", c => c.String(nullable: false));
            AlterColumn("dbo.faculty_task_assign", "description", c => c.String(nullable: false));
            AlterColumn("dbo.faculty_task_assign", "priority", c => c.String(nullable: false));
            AlterColumn("dbo.Staff_Application", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Staff_Application", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Staff_Application", "description", c => c.String(nullable: false));
            AlterColumn("dbo.staff_task_assign", "title", c => c.String(nullable: false));
            AlterColumn("dbo.staff_task_assign", "description", c => c.String(nullable: false));
            AlterColumn("dbo.student_task_assign", "title", c => c.String(nullable: false));
            AlterColumn("dbo.student_task_assign", "description", c => c.String(nullable: false));
            AlterColumn("dbo.student_task_assign", "priority", c => c.String(nullable: false));
            DropColumn("dbo.faculty_task_assign", "status");
            DropColumn("dbo.staff_task_assign", "status");
            DropColumn("dbo.student_task_assign", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.student_task_assign", "status", c => c.String());
            AddColumn("dbo.staff_task_assign", "status", c => c.String());
            AddColumn("dbo.faculty_task_assign", "status", c => c.String());
            AlterColumn("dbo.student_task_assign", "priority", c => c.String());
            AlterColumn("dbo.student_task_assign", "description", c => c.String());
            AlterColumn("dbo.student_task_assign", "title", c => c.String());
            AlterColumn("dbo.staff_task_assign", "description", c => c.String());
            AlterColumn("dbo.staff_task_assign", "title", c => c.String());
            AlterColumn("dbo.Staff_Application", "description", c => c.String());
            AlterColumn("dbo.Staff_Application", "title", c => c.String());
            AlterColumn("dbo.Staff_Application", "name", c => c.String());
            AlterColumn("dbo.faculty_task_assign", "priority", c => c.String());
            AlterColumn("dbo.faculty_task_assign", "description", c => c.String());
            AlterColumn("dbo.faculty_task_assign", "title", c => c.String());
            AlterColumn("dbo.Faculty_Application", "description", c => c.String());
            AlterColumn("dbo.Faculty_Application", "title", c => c.String());
            AlterColumn("dbo.Faculty_Application", "name", c => c.String());
            AlterColumn("dbo.Applications", "description", c => c.String());
            AlterColumn("dbo.Applications", "title", c => c.String());
            AlterColumn("dbo.Applications", "name", c => c.String());
        }
    }
}
