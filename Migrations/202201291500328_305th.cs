namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _305th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.namesAniks",
                c => new
                    {
                        nid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.nid);
            
            CreateTable(
                "dbo.rollAniks",
                c => new
                    {
                        rid = c.Int(nullable: false, identity: true),
                        Roll = c.String(),
                    })
                .PrimaryKey(t => t.rid);
            
         
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.anikRolls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Roll = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.anikNames",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
          
        }
    }
}
