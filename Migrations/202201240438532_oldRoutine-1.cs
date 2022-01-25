namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldRoutine1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.oldRoutines",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        routine_upload = c.String(),
                        class_date = c.DateTime(nullable: false),
                        day = c.String(nullable: false),
                        teacher_id = c.Int(),
                        subject_id = c.Int(),
                        session_id = c.Int(),
                        year_id = c.Int(),
                        start_time = c.Time(nullable: false, precision: 7),
                        end_time = c.Time(nullable: false, precision: 7),
                        duration = c.String(nullable: false),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.teachers", t => t.teacher_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.teacher_id)
                .Index(t => t.subject_id)
                .Index(t => t.session_id)
                .Index(t => t.year_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.oldRoutines", "year_id", "dbo.Years");
            DropForeignKey("dbo.oldRoutines", "teacher_id", "dbo.teachers");
            DropForeignKey("dbo.oldRoutines", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.oldRoutines", "session_id", "dbo.Sessions");
            DropIndex("dbo.oldRoutines", new[] { "year_id" });
            DropIndex("dbo.oldRoutines", new[] { "session_id" });
            DropIndex("dbo.oldRoutines", new[] { "subject_id" });
            DropIndex("dbo.oldRoutines", new[] { "teacher_id" });
            DropTable("dbo.oldRoutines");
        }
    }
}
