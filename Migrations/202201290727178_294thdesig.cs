namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _294thdesig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.designationEms",
                c => new
                    {
                        did = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.did);
            
            CreateTable(
                "dbo.designationMoes",
                c => new
                    {
                        did = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.did);
            
            CreateTable(
                "dbo.designationShas",
                c => new
                    {
                        did = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.did);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.designationShas");
            DropTable("dbo.designationMoes");
            DropTable("dbo.designationEms");
        }
    }
}
