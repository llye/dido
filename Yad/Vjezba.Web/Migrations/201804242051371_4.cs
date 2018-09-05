namespace Vjezba.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Korisnicis", newName: "Prodavacs");
            RenameColumn(table: "dbo.Narudzbes", name: "KorisniciId", newName: "ProdavacId");
            RenameIndex(table: "dbo.Narudzbes", name: "IX_KorisniciId", newName: "IX_ProdavacId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Narudzbes", name: "IX_ProdavacId", newName: "IX_KorisniciId");
            RenameColumn(table: "dbo.Narudzbes", name: "ProdavacId", newName: "KorisniciId");
            RenameTable(name: "dbo.Prodavacs", newName: "Korisnicis");
        }
    }
}
