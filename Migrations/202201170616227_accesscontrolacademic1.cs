namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accesscontrolacademic1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.book11",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book12",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book21",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book22",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book31",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book32",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book41",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.book42",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        year_id = c.Int(),
                        book_name = c.String(nullable: false),
                        book_author = c.String(nullable: false),
                        specification = c.String(nullable: false),
                        edition = c.String(),
                        subject_id = c.Int(),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.year_id)
                .Index(t => t.subject_id);
            
            CreateTable(
                "dbo.materials11",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials12",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials21",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials22",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials31",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials32",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials41",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.materials42",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.notice11",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice12",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice21",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice22",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice31",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice32",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice41",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.notice42",
                c => new
                    {
                        notice_id = c.Int(nullable: false, identity: true),
                        notice_upload = c.String(nullable: false),
                        notice_topic = c.String(nullable: false),
                        published_by = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        updated_by = c.String(),
                        updated_date = c.DateTime(nullable: false),
                        deadline = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.notice_id);
            
            CreateTable(
                "dbo.routine11",
                c => new
                    {
                        materials_id = c.Int(nullable: false, identity: true),
                        subject_id = c.Int(),
                        year_id = c.Int(),
                        materials_topic = c.String(nullable: false),
                        arranged_by = c.String(nullable: false),
                        reference = c.String(),
                        publish_date = c.DateTime(nullable: false),
                        specification = c.String(),
                    })
                .PrimaryKey(t => t.materials_id)
                .ForeignKey("dbo.Subjects", t => t.subject_id)
                .ForeignKey("dbo.Years", t => t.year_id)
                .Index(t => t.subject_id)
                .Index(t => t.year_id);
            
            CreateTable(
                "dbo.routine12",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine21",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine22",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine31",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine32",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine41",
                c => new
                    {
                        routine_id = c.Int(nullable: false, identity: true),
                        session_id = c.Int(),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.routine_id)
                .ForeignKey("dbo.Sessions", t => t.session_id)
                .Index(t => t.session_id);
            
            CreateTable(
                "dbo.routine42",
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
            DropForeignKey("dbo.routine42", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine41", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine32", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine31", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine22", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine21", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine12", "session_id", "dbo.Sessions");
            DropForeignKey("dbo.routine11", "year_id", "dbo.Years");
            DropForeignKey("dbo.routine11", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials42", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials42", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials41", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials41", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials32", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials32", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials31", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials31", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials22", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials22", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials21", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials21", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials12", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials12", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.materials11", "year_id", "dbo.Years");
            DropForeignKey("dbo.materials11", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book42", "year_id", "dbo.Years");
            DropForeignKey("dbo.book42", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book41", "year_id", "dbo.Years");
            DropForeignKey("dbo.book41", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book32", "year_id", "dbo.Years");
            DropForeignKey("dbo.book32", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book31", "year_id", "dbo.Years");
            DropForeignKey("dbo.book31", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book22", "year_id", "dbo.Years");
            DropForeignKey("dbo.book22", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book21", "year_id", "dbo.Years");
            DropForeignKey("dbo.book21", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book12", "year_id", "dbo.Years");
            DropForeignKey("dbo.book12", "subject_id", "dbo.Subjects");
            DropForeignKey("dbo.book11", "year_id", "dbo.Years");
            DropForeignKey("dbo.book11", "subject_id", "dbo.Subjects");
            DropIndex("dbo.routine42", new[] { "session_id" });
            DropIndex("dbo.routine41", new[] { "session_id" });
            DropIndex("dbo.routine32", new[] { "session_id" });
            DropIndex("dbo.routine31", new[] { "session_id" });
            DropIndex("dbo.routine22", new[] { "session_id" });
            DropIndex("dbo.routine21", new[] { "session_id" });
            DropIndex("dbo.routine12", new[] { "session_id" });
            DropIndex("dbo.routine11", new[] { "year_id" });
            DropIndex("dbo.routine11", new[] { "subject_id" });
            DropIndex("dbo.materials42", new[] { "year_id" });
            DropIndex("dbo.materials42", new[] { "subject_id" });
            DropIndex("dbo.materials41", new[] { "year_id" });
            DropIndex("dbo.materials41", new[] { "subject_id" });
            DropIndex("dbo.materials32", new[] { "year_id" });
            DropIndex("dbo.materials32", new[] { "subject_id" });
            DropIndex("dbo.materials31", new[] { "year_id" });
            DropIndex("dbo.materials31", new[] { "subject_id" });
            DropIndex("dbo.materials22", new[] { "year_id" });
            DropIndex("dbo.materials22", new[] { "subject_id" });
            DropIndex("dbo.materials21", new[] { "year_id" });
            DropIndex("dbo.materials21", new[] { "subject_id" });
            DropIndex("dbo.materials12", new[] { "year_id" });
            DropIndex("dbo.materials12", new[] { "subject_id" });
            DropIndex("dbo.materials11", new[] { "year_id" });
            DropIndex("dbo.materials11", new[] { "subject_id" });
            DropIndex("dbo.book42", new[] { "subject_id" });
            DropIndex("dbo.book42", new[] { "year_id" });
            DropIndex("dbo.book41", new[] { "subject_id" });
            DropIndex("dbo.book41", new[] { "year_id" });
            DropIndex("dbo.book32", new[] { "subject_id" });
            DropIndex("dbo.book32", new[] { "year_id" });
            DropIndex("dbo.book31", new[] { "subject_id" });
            DropIndex("dbo.book31", new[] { "year_id" });
            DropIndex("dbo.book22", new[] { "subject_id" });
            DropIndex("dbo.book22", new[] { "year_id" });
            DropIndex("dbo.book21", new[] { "subject_id" });
            DropIndex("dbo.book21", new[] { "year_id" });
            DropIndex("dbo.book12", new[] { "subject_id" });
            DropIndex("dbo.book12", new[] { "year_id" });
            DropIndex("dbo.book11", new[] { "subject_id" });
            DropIndex("dbo.book11", new[] { "year_id" });
            DropTable("dbo.routine42");
            DropTable("dbo.routine41");
            DropTable("dbo.routine32");
            DropTable("dbo.routine31");
            DropTable("dbo.routine22");
            DropTable("dbo.routine21");
            DropTable("dbo.routine12");
            DropTable("dbo.routine11");
            DropTable("dbo.notice42");
            DropTable("dbo.notice41");
            DropTable("dbo.notice32");
            DropTable("dbo.notice31");
            DropTable("dbo.notice22");
            DropTable("dbo.notice21");
            DropTable("dbo.notice12");
            DropTable("dbo.notice11");
            DropTable("dbo.materials42");
            DropTable("dbo.materials41");
            DropTable("dbo.materials32");
            DropTable("dbo.materials31");
            DropTable("dbo.materials22");
            DropTable("dbo.materials21");
            DropTable("dbo.materials12");
            DropTable("dbo.materials11");
            DropTable("dbo.book42");
            DropTable("dbo.book41");
            DropTable("dbo.book32");
            DropTable("dbo.book31");
            DropTable("dbo.book22");
            DropTable("dbo.book21");
            DropTable("dbo.book12");
            DropTable("dbo.book11");
        }
    }
}
