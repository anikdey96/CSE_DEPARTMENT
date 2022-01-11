namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.faculty_task_assign",
                c => new
                    {
                        task_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        deadline = c.String(),
                        priority = c.String(),
                        status = c.String(),
                        feedback = c.String(),
                    })
                .PrimaryKey(t => t.task_id);
            
            CreateTable(
                "dbo.staff_task_assign",
                c => new
                    {
                        task_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        deadline = c.String(),
                        priority = c.String(),
                        status = c.String(),
                        feedback = c.String(),
                    })
                .PrimaryKey(t => t.task_id);
            
            CreateTable(
                "dbo.student_task_assign",
                c => new
                    {
                        task_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        deadline = c.String(),
                        priority = c.String(),
                        status = c.String(),
                        feedback = c.String(),
                    })
                .PrimaryKey(t => t.task_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.student_task_assign");
            DropTable("dbo.staff_task_assign");
            DropTable("dbo.faculty_task_assign");
        }
    }
}
