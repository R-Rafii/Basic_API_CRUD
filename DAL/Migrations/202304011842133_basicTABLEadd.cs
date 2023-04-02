namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicTABLEadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Cid" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
