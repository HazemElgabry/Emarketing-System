namespace Phase_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAndCategoryTables1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.Int(nullable: false));
        }
    }
}
