namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectcredit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Credit", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Credit");
        }
    }
}
