namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrasikedua : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        price = c.String(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Supplier", t => t.Supplier_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "Supplier_Id" });
            DropTable("dbo.Tb_M_Item");
        }
    }
}
