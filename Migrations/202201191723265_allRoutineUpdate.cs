namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allRoutineUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.routines", "year_id", c => c.Int());
            AddColumn("dbo.routine12", "year_id", c => c.Int());
            AddColumn("dbo.routine21", "year_id", c => c.Int());
            AddColumn("dbo.routine22", "year_id", c => c.Int());
            AddColumn("dbo.routine31", "year_id", c => c.Int());
            AddColumn("dbo.routine32", "year_id", c => c.Int());
            AddColumn("dbo.routine41", "year_id", c => c.Int());
            AddColumn("dbo.routine42", "year_id", c => c.Int());
            CreateIndex("dbo.routines", "year_id");
            CreateIndex("dbo.routine12", "year_id");
            CreateIndex("dbo.routine21", "year_id");
            CreateIndex("dbo.routine22", "year_id");
            CreateIndex("dbo.routine31", "year_id");
            CreateIndex("dbo.routine32", "year_id");
            CreateIndex("dbo.routine41", "year_id");
            CreateIndex("dbo.routine42", "year_id");
            AddForeignKey("dbo.routines", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine12", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine21", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine22", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine31", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine32", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine41", "year_id", "dbo.Years", "year_id");
            AddForeignKey("dbo.routine42", "year_id", "dbo.Years", "year_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.routine42", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine41", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine32", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine31", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine22", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine21", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine12", "year_id", "dbo.Years");
            DropForeignKey("dbo.routines", "year_id", "dbo.Years");
            DropIndex("dbo.routine42", new[] { "year_id" });
            DropIndex("dbo.routine41", new[] { "year_id" });
            DropIndex("dbo.routine32", new[] { "year_id" });
            DropIndex("dbo.routine31", new[] { "year_id" });
            DropIndex("dbo.routine22", new[] { "year_id" });
            DropIndex("dbo.routine21", new[] { "year_id" });
            DropIndex("dbo.routine12", new[] { "year_id" });
            DropIndex("dbo.routines", new[] { "year_id" });
            DropColumn("dbo.routine42", "year_id");
            DropColumn("dbo.routine41", "year_id");
            DropColumn("dbo.routine32", "year_id");
            DropColumn("dbo.routine31", "year_id");
            DropColumn("dbo.routine22", "year_id");
            DropColumn("dbo.routine21", "year_id");
            DropColumn("dbo.routine12", "year_id");
            DropColumn("dbo.routines", "year_id");
        }
    }
}
