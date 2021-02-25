namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIcollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessionstudents", "Session_session_id", "dbo.Sessions");
            DropForeignKey("dbo.Sessionstudents", "student_student_id", "dbo.students");
            DropIndex("dbo.Sessionstudents", new[] { "Session_session_id" });
            DropIndex("dbo.Sessionstudents", new[] { "student_student_id" });
            CreateIndex("dbo.students", "session_id");
            AddForeignKey("dbo.students", "session_id", "dbo.Sessions", "session_id");
            DropTable("dbo.Sessionstudents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sessionstudents",
                c => new
                    {
                        Session_session_id = c.Int(nullable: false),
                        student_student_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Session_session_id, t.student_student_id });
            
            DropForeignKey("dbo.students", "session_id", "dbo.Sessions");
            DropIndex("dbo.students", new[] { "session_id" });
            CreateIndex("dbo.Sessionstudents", "student_student_id");
            CreateIndex("dbo.Sessionstudents", "Session_session_id");
            AddForeignKey("dbo.Sessionstudents", "student_student_id", "dbo.students", "student_id", cascadeDelete: true);
            AddForeignKey("dbo.Sessionstudents", "Session_session_id", "dbo.Sessions", "session_id", cascadeDelete: true);
        }
    }
}
