namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.current_academic", "Roll_No", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.current_academic", "Roll_No");
        }
    }
}
