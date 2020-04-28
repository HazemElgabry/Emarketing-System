
namespace Phase_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        product_Id = c.Int(nullable: false),
                        added_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_Id, cascadeDelete: true)
                .Index(t => t.product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "product_Id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "product_Id" });
            DropTable("dbo.Carts");
        }
    }
}
