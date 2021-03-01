namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _in : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.current_academic", "Roll", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.current_academic", "Roll");
        }
    }
}
