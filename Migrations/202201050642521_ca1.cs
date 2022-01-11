namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ca1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.current_academic", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.current_academic", "Email");
        }
    }
}
