namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _300th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.anikNames",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.anikRolls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Roll = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.anikRolls");
            DropTable("dbo.anikNames");
        }
    }
}
