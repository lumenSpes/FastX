namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "ProductId", newName: "InventoryId");
            RenameIndex(table: "dbo.Orders", name: "IX_ProductId", newName: "IX_InventoryId");
            AddColumn("dbo.Orders", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Amount");
            RenameIndex(table: "dbo.Orders", name: "IX_InventoryId", newName: "IX_ProductId");
            RenameColumn(table: "dbo.Orders", name: "InventoryId", newName: "ProductId");
        }
    }
}
