namespace Phase_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableToPKandFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "product_Id", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "product_Id");
            AddForeignKey("dbo.Carts", "product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Carts", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Carts", "product_Id", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "id");
            AddForeignKey("dbo.Carts", "product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
