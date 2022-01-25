namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oldROUTINE11 : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.oldRoutine11",
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
          
        }
    }
}
