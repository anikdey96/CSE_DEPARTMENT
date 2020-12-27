namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignrole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.RoleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
