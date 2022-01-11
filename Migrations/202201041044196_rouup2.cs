namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rouup2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.routines", name: "teacher_id", newName: "teacher_teacher_id");
            RenameColumn(table: "dbo.routines", name: "subject_id", newName: "Subject_subject_id");
            RenameIndex(table: "dbo.routines", name: "IX_subject_id", newName: "IX_Subject_subject_id");
            RenameIndex(table: "dbo.routines", name: "IX_teacher_id", newName: "IX_teacher_teacher_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.routines", name: "IX_teacher_teacher_id", newName: "IX_teacher_id");
            RenameIndex(table: "dbo.routines", name: "IX_Subject_subject_id", newName: "IX_subject_id");
            RenameColumn(table: "dbo.routines", name: "Subject_subject_id", newName: "subject_id");
            RenameColumn(table: "dbo.routines", name: "teacher_teacher_id", newName: "teacher_id");
        }
    }
}
