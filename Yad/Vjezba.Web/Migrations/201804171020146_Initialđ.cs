namespace Vjezba.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialđ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        BuyPrice = c.String(),
                        SellPrice = c.String(),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
