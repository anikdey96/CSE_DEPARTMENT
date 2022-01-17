﻿namespace CSE_DEPARTMENT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleSel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleSelected", c => c.String());
        }
    }
}
