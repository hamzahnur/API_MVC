namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrasiketiga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "Supplier_Id" });
            RenameColumn(table: "dbo.Tb_M_Item", name: "Supplier_Id", newName: "SupplierID");
            AlterColumn("dbo.Tb_M_Item", "SupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tb_M_Item", "SupplierID");
            AddForeignKey("dbo.Tb_M_Item", "SupplierID", "dbo.Tb_M_Supplier", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Item", "SupplierID", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "SupplierID" });
            AlterColumn("dbo.Tb_M_Item", "SupplierID", c => c.Int());
            RenameColumn(table: "dbo.Tb_M_Item", name: "SupplierID", newName: "Supplier_Id");
            CreateIndex("dbo.Tb_M_Item", "Supplier_Id");
            AddForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier", "Id");
        }
    }
}
