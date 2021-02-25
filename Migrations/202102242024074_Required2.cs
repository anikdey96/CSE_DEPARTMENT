namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.students", "Photo", c => c.String());
            AlterColumn("dbo.Staffs", "Photo", c => c.String());
            AlterColumn("dbo.teachers", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.teachers", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.students", "Photo", c => c.String(nullable: false));
        }
    }
}
