namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _600th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.appliMahins",
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
                .ForeignKey("dbo.nameMahins", t => t.nid)
                .ForeignKey("dbo.rollMahins", t => t.rid)
                .Index(t => t.nid)
                .Index(t => t.rid);
            
            CreateTable(
                "dbo.indexAppliAniks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Roll = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.indexAppliArsads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalLeave = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.indexAppliImruls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalLeave = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.indexAppliMahins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Roll = c.Int(nullable: false),
                        LeaveTaken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.appliMahins", "rid", "dbo.rollMahins");
            DropForeignKey("dbo.appliMahins", "nid", "dbo.nameMahins");
            DropIndex("dbo.appliMahins", new[] { "rid" });
            DropIndex("dbo.appliMahins", new[] { "nid" });
            DropTable("dbo.indexAppliMahins");
            DropTable("dbo.indexAppliImruls");
            DropTable("dbo.indexAppliArsads");
            DropTable("dbo.indexAppliAniks");
            DropTable("dbo.appliMahins");
        }
    }
}
