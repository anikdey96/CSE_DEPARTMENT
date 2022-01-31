namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _400th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.appliAniks",
                c => new
                    {
                        aid = c.Int(nullable: false, identity: true),
                        nid = c.Int(),
                        rid = c.Int(),
                        title = c.String(nullable: false),
                        requiredLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.aid)
                .ForeignKey("dbo.namesAniks", t => t.nid)
                .ForeignKey("dbo.rollAniks", t => t.rid)
                .Index(t => t.nid)
                .Index(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.appliAniks", "rid", "dbo.rollAniks");
            DropForeignKey("dbo.appliAniks", "nid", "dbo.namesAniks");
            DropIndex("dbo.appliAniks", new[] { "rid" });
            DropIndex("dbo.appliAniks", new[] { "nid" });
            DropTable("dbo.appliAniks");
        }
    }
}
