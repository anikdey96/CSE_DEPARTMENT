namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _out : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.current_academic", "Roll_No");
        }
        
        public override void Down()
        {
            AddColumn("dbo.current_academic", "Roll_No", c => c.Int(nullable: false));
        }
    }
}
