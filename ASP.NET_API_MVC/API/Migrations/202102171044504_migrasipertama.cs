﻿namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrasipertama : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_M_Supplier");
        }
    }
}
