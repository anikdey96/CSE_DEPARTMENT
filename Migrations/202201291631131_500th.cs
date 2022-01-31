namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _500th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.appliArsads",
                c => new
                    {
                        aid = c.Int(nullable: false, identity: true),
                        nid = c.Int(),
                        title = c.String(nullable: false),
                        requiredLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.aid)
                .ForeignKey("dbo.nameArsads", t => t.nid)
                .Index(t => t.nid);
            
            CreateTable(
                "dbo.nameArsads",
                c => new
                    {
                        nid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.nid);
            
            CreateTable(
                "dbo.appliImruls",
                c => new
                    {
                        aid = c.Int(nullable: false, identity: true),
                        nid = c.Int(),
                        title = c.String(nullable: false),
                        requiredLeave = c.Int(nullable: false),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.aid)
                .ForeignKey("dbo.nameImruls", t => t.nid)
                .Index(t => t.nid);
            
            CreateTable(
                "dbo.nameImruls",
                c => new
                    {
                        nid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.nid);
            
            CreateTable(
                "dbo.nameMahins",
                c => new
                    {
                        nid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.nid);
            
            CreateTable(
                "dbo.rollMahins",
                c => new
                    {
                        rid = c.Int(nullable: false, identity: true),
                        Roll = c.String(),
                    })
                .PrimaryKey(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.appliImruls", "nid", "dbo.nameImruls");
            DropForeignKey("dbo.appliArsads", "nid", "dbo.nameArsads");
            DropIndex("dbo.appliImruls", new[] { "nid" });
            DropIndex("dbo.appliArsads", new[] { "nid" });
            DropTable("dbo.rollMahins");
            DropTable("dbo.nameMahins");
            DropTable("dbo.nameImruls");
            DropTable("dbo.appliImruls");
            DropTable("dbo.nameArsads");
            DropTable("dbo.appliArsads");
        }
    }
}
