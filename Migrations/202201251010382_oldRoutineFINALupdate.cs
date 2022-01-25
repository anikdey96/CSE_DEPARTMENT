namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldRoutineFINALupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.oldRoutine_12",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_21",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_22",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_31",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_32",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_41",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.oldRoutine_42",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        box1 = c.String(),
                        box2 = c.String(),
                        box3 = c.String(),
                        box4 = c.String(),
                        box5 = c.String(),
                        box6 = c.String(),
                        box7 = c.String(),
                        box8 = c.String(),
                        box9 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.oldRoutine_42");
            DropTable("dbo.oldRoutine_41");
            DropTable("dbo.oldRoutine_32");
            DropTable("dbo.oldRoutine_31");
            DropTable("dbo.oldRoutine_22");
            DropTable("dbo.oldRoutine_21");
            DropTable("dbo.oldRoutine_12");
        }
    }
}
