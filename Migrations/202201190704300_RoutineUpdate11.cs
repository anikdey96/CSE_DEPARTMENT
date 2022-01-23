namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoutineUpdate11 : DbMigration
    {
        public override void Up()
        {
          
            CreateTable(
                "dbo.rou11",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
           
        }
        
        public override void Down()
        {
           
        }
    }
}
