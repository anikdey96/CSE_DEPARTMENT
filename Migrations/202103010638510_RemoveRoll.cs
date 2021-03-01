namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoll : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "Roll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.current_academic", "Roll", c => c.Int(nullable: false));
        }
    }
}
