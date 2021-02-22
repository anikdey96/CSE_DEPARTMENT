namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectCourse2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Credit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Credit", c => c.Single(nullable: false));
        }
    }
}
