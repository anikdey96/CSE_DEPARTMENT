namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Int64 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.previous_academic", "hsc_reg", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.previous_academic", "hsc_reg", c => c.Int(nullable: false));
        }
    }
}
